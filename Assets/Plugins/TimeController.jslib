mergeInto(LibraryManager.library, 
{

  AlertMoscowTime: function (str) {
    var newWin = window.open("about:blank");
    newWin.alert(UTF8ToString(str));
  },


});