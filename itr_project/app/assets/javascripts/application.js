//= require jquery
//= require jquery-ui
//= require jquery_ujs
//= require jquery.cookie
//= require ckeditor/init
//= require bootstrap
//= require ckeditor_onchange
//= require_tree .


$(function() {

  var ac = $("#autocomplete");

  ac.autocomplete({
      source: "/tags.json",
      minLength: 2,
      select: function( event, ui ) {
        var values = ac.val().split(", ");
        values.pop();
        values.push(ui.item.value);
        ac.val(values.join(", "));
        return false;
      },

      focus: function(event, ui) {
        return false;
      }
    });
});




  $(function() {
    $( "#header" ).draggable(); 
  });





  $(function() {
    $(".link_dark").click(function() {
      $.cookie('design', 'dark');
      location.reload();
     });
  });

  $(function() {
    $(".link_light").click(function() {
     $.cookie('design', 'light');
      location.reload();
    });
  });








  $(document).ready(function() {
    var q = $.cookie('design'); 
    if( !(q == null) )
      {
       $('body').addClass(q);
      }
    else
      {
       $('body').addClass('light');  
      }  
  });


  $(function() {
    var value = CKEDITOR.instances.task_content.getData();
    setInterval(function() {
      if (CKEDITOR.instances.task_content.getData() != value) {
        value = CKEDITOR.instances.task_content.getData();
        $.post("/tasks/persisted_store", {
          data: value
        });
      }
    }, 1000);
  });
