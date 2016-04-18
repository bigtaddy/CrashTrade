function ajaxifyPagination() {
  $(".pagination a").attr("data-remote", true);
}

$(function() {
  ajaxifyPagination();
});
