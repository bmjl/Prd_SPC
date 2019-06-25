$(function () {
    $("#btn_commit").click(function () {
        Commit();
    });
    $("#ArrayNum").keydown(function (event) {
        if (event.keyCode == 13) {
            Commit();
        }
    }); 
})
function Commit() {
    //int setid,int ArrayX, int ArrayY,string  ArrayNum 
    var _setid = $("#Set_id").val();
    var _ArrayX = $("#ArrayX").val();
    var _ArrayY = $("#ArrayY").val();
    var _ArrayNum = $("#ArrayNum").val().trim();//去掉前后空格
    var _SerrialNum = $("#SerrialNum").val();
    if (_ArrayNum == null || _ArrayNum == '') {
        $("#ArrayNum").focus();

    } else {
        $.post("/SamplDatas/Create_P", { setid: _setid, ArrayX: _ArrayX, ArrayY: _ArrayY, ArrayNum: _ArrayNum, SerialNumber: _SerrialNum }, function (data) {
            if (data == "ok") {
                var id = '#' + _ArrayX + '_' + _ArrayY;
                $(id).text(_ArrayNum);
                $("#ArrayNum").val('');
                $("#ArrayNum").focus();
                var x = $(".MaxNum").attr("max_x");
                var y = $(".MaxNum").attr("max_y");
                if (_ArrayY == y) {
                    $("#ArrayX").val(parseInt(_ArrayX) + 1);
                    $("#ArrayY").val(0)
                } else {
                    $("#ArrayY").val(parseInt(_ArrayY) + 1);
                }
            } else {
                $.messager.alert("系统提示", "添加失败", "error");
            }
        }, "json");
    }
}