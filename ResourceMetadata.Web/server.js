(function () {

    'use strict';

    var PORT = 7777,
        PROXY_URL = 'http://localhost:7888';

    var http = require('http'),
        url = require('url'),
        path = require('path'),
        fs = require('fs'),
        request = require('request'),
        mime = require('mime');

    var server = http.createServer(function (req, res) {
        var urlData = url.parse(req.url),
            theUrl = urlData.pathname,
            someFileName = path.join(process.cwd(), theUrl);

        res.on('error', function (err) {
            console.log(err);
        });

        if (~theUrl.indexOf('api') || ~theUrl.indexOf('Token')) {
            var proxyUrl = PROXY_URL + theUrl + (urlData.search || '');
            var proxyStream = request(proxyUrl);
            proxyStream.on('error', function (e) {
                console.log(e);
                res.end();
                proxyStream.destroy();
            });

            req.pipe(proxyStream).pipe(res);

            req.on('close', function () {
                proxyStream.destroy();
                res.destroy();
            });

        } else {
            if (theUrl === '/') {
                someFileName += 'index.html';
            }
            fs.exists(someFileName, function (exists) {
                var type = mime.lookup(someFileName);
                type += '; charset=utf-8';
                if (!exists) {
                    res.writeHead(404, {'Content-Type': 'text/plain'});
                    res.write('404 Nothing Here\n');
                    res.end();
                    return;
                }
                fs.readFile(someFileName, function (err, file) {
                    if (err) {
                        res.writeHead(500, {'Content-Type': 'text/plain'});
                        res.write(err + '\n');
                        res.end();
                        return;
                    }

                    res.writeHead(200, {
                        'Content-Type': type,
                        'Content-length': file.length
                    });
                    res.write(file, 'binary');
                    res.end();
                });
            });
        }
    });

    server.listen(PORT);

    console.log('Server running at http://localhost:' + PORT);

    server.on('error', function () {
        server.listen(PORT);
    });

}());

