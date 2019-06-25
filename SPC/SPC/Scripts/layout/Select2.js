$(function () {
    //选择类别
   

    var type = 0;
   
    //$(".btn_select").click(function () {
    $(".select_data").children().remove();
    $(".select_data").append('<option value="0">请选择</option>');


        $.get("/Select/Index?id=0&type=1", function (data) {
            if (data != null) {
                for (var i = 0; i < data.length; i++) {
                    $("#dpt2").append('<option value="' + data[i].DptId + '">' + data[i].DptName + '</option>');
                }
            }
        });

         type = $(this).attr("value");
        
   // });  

    $('#dpt2').change(function () {

        var name = $(this).children('option:selected').text();
        var id = $(this).children('option:selected').val();
        if (type == 1) {
            //$("#DepName").val(name);
            //$("#depId").val(id);
        } else {
            $.get("/Select/Index?id=" + id + "&type=2", function (data) {
                if (data != null) {
                    for (var i = 0; i < data.length; i++) {
                        $("#prd2").append('<option value="' + data[i].PrdId + '">' + data[i].PrdName + '</option>');
                    }
                }
            });
        }
    });
    $('#prd2').change(function () {
        var name = $(this).children('option:selected').text();
        var id = $(this).children('option:selected').val();
        if (type == 2) {          
            //$("#prd_Name").val(name);
            //$("#prd_id").val(id);
        } else {
            $.get("/Select/Index?id=" + id + "&type=3", function (data) {
                if (data != null) {
                    for (var i = 0; i < data.length; i++) {
                        $("#pjt2").append('<option value="' + data[i].PjtId + '">' + data[i].PjtName + '</option>');
                    }
                }
            });
        }
    });
    $('#pjt2').change(function () {
        var name = $(this).children('option:selected').text();
        var id = $(this).children('option:selected').val();
        if (type == 3) {
            //$("#project_Name").val(name);
            //$("#project_id").val(id);
        } else {
            $.get("/Select/Index?id=" + id + "&type=4", function (data) {
                if (data != null) {
                    for (var i = 0; i < data.length; i++) {
                        $("#set2").append('<option x=' + data[i].X + ' y=' + data[i].Y + '  value="' + data[i].SetId + '">' + data[i].SetName + '</option>');
                    }
                }
            });
        }
    });
    $('#set2').change(function () {
        var name = $(this).children('option:selected').text();
        var id = $(this).children('option:selected').val();
        var xx = $(this).children('option:selected').attr("x");
        var yy = $(this).children('option:selected').attr("y");
        //缓存数据
        document.cookie = "data_id=" + id;
        getdata(id);
       // }
    });
    var id = getCookie("data_id");
    if (id != null) {
        getdata(id);
    }
});
function getdata(id) {
    //获取数据
    $.get("/Select/GetData?id=" + id + "&type=4", function (data) {
        if (data != null) {
            var html = "";
            $("#datas").html("<tr><th> 编号</th ></tr >");
            for (var i = 0; i < data.length; i++) {
                //html = "<tr><td viewtype=" + data[i].ViewType + ">" + data[i].SerialNumber + "</td></tr>"
                var vt = data[i].ViewType.trim();
                if (vt == "X-R") {
                    html = "<tr><td><a href='/DrawView/XR?SetId=" + data[i].Set_id + "&SN=" + data[i].SerialNumber + "'>" + data[i].SerialNumber + "</a></td></tr>";
                } else if (vt == "X-S") {
                    html = "<tr><td><a href='/DrawView/XS?SetId=" + data[i].Set_id + "&SN=" + data[i].SerialNumber + "'>" + data[i].SerialNumber + "</a></td></tr>";
                } else if (vt == "X-MR") {
                    html = "<tr><td><a href='/DrawView/XMR?SetId=" + data[i].Set_id + "&SN=" + data[i].SerialNumber + "'>" + data[i].SerialNumber + "</a></td></tr>";
                }
                $("#datas").append(html);
                //<a href="/SamplDatas">数据设置</a>
                //$("#set2").append('<option value="' + data[i].PjtId + '">' + data[i].PjtName + '</option>');
            }
        }
    });
}
function getCookie(name) {
    var arr, reg = new RegExp("(^| )" + name + "=([^;]*)(;|$)");
    if (arr = document.cookie.match(reg))
        return unescape(arr[2]);
    else
        return null;
}
