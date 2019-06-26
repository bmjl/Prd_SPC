//所有的和
var AllSum = 0;
//所有极差的和
var AllAvgSum = 0;
$(function () {

   
    //$(".btn").click(function() {
    //    $(this).button('loading').delay(10).queue(function() {
    //        $(this).button('reset');
    //        $(this).dequeue();
    //    });
    //});
    $(".div_collapse").click(function() {
        var s = $(this).attr("state");
        if (s == 1) {
            $(this).attr("state", 0);
            $(this).children().children().text("收起");
        } else {
            $(this).attr("state", 1);
            $(this).children().children().text("展开");
        }
    })
    var setid = GetUrlParam("SetId");
    var sn = GetUrlParam("SN");
    var x = 0; y = 0;
    var UCL = "", CL = "", LCL = "";
    var arr_xs = new Array();
    $.get("/DrawView/GetSettingData?SetId=" + setid + "", function (data) {
        if (data != null) {
            x = data.Group_Num;
            y = data.Group_Total;
            UCL = data.UCL;
            CL = data.CL;
            LCL = data.LCL;
            $("#ucl").text(UCL);
            $("#cl").text(CL);
            $("#lcl").text(LCL);
            $("#x").text(x);
            $("#y").text(y);
           
           
            //初始化，定下有多少行
            for (var i = 0; i < y; i++) {
                arr_xs[i] = new Array();
                for (var j = 0; j < x; j++) {
                    arr_xs[i][j] = 0;
                }
            }

            //    //等于0说明还没有获取到设定值，需要等待
            $.get("/DrawView/GetSamplData?SN=" + sn + "", function (data) {
                if (data != null) {
                    var xx = 0, yy = 0, num = "";
                    for (var i = 0; i < data.length; i++) {
                        xx = data[i].ArrayX;
                        yy = data[i].ArrayY;
                        num = data[i].ArrayNum;
                        arr_xs[yy][xx] = parseFloat(num);
                    }

                    var html = "";
                    var ii = 0;
                    var html_th = "";

                    if (arr_xs.length != 5) {
                        var x = 0;
                        $('#_thead').append('<th  class="border">序号</th>');
                        for (var i = 0; i < arr_xs[0].length; i++) {
                            x = i + 1;
                            $('#_thead').append('<th class="border" >' + x + '</th>');
                        }
                        $('#_thead').append('<th class="border">ΣＸ</th><th  class="border">Ｘ</th><th  class="border">S</th>');
                        $('#_head').hide();
                    }
                    var xs = new Array();
                    for (var i = 0; i < arr_xs.length; i++) {
                        ii = i + 1;
                        html += '<tr class="max_width">';
                        html += '<td> ' + ii + '</td >';
                        for (var j = 0; j < arr_xs[i].length; j++) {
                            //html += '<td><input type="text" value="' + fixed2(arr_xs[i][j]) + '"></td>';
                            html += '<td>' + fixed2(arr_xs[i][j]) + '</td>';
                            xs[j] = arr_xs[i][j];
                        }
                        html += _js(xs);
                        html += '</tr>';
                        $("#parameter").append(html);
                        html = "";
                        $("#par").hide();
                    }

                    //获取常数值数值
                    $.get("/DrawView/GetControlConstants?GroupNum=" + x + "", function (data) {
                        if (data != null) {
                            //X 上中下
                            //上：所有的平均数 + A3(常数）*极差的平均数                        
                            var ucl_num = AllSum / y + (data.A3) * (AllAvgSum / y);
                            $("#ucl_num").html(fixed3(ucl_num));
                            //中
                            var cl_num = AllSum / y;
                            $("#cl_num").html(fixed3(cl_num));
                            //下
                            var lcl_num = AllSum / y - (data.A3) * (AllAvgSum / y);
                            $("#lcl_num").html(fixed3(lcl_num));

                            //S 上中下
                            //上
                            var s_ucl_num = (data.B4) * (AllAvgSum / y);
                            $("#s_ucl_num").html(fixed3(s_ucl_num));
                            //中
                            var s_cl_num = AllAvgSum / y;
                            $("#s_cl_num").html(fixed3(s_cl_num));
                            //下
                            var s_lcl_num = (data.B3) * (AllAvgSum / y);
                            $("#s_lcl_num").html(fixed3(s_lcl_num));
                            //画图
                            X();
                            S();
                        }
                    });





                   
                }
            });
        }
    });

      

    
   

    //var arr = [
    //    [16.00, 16.00, 16.00, 15.00, 16.00, 13.00, 13.00, 14.00, 13.00, 15.00, 11.00, 17.00, 20.00, 18.00, 12.00, 11.00, 17.00, 13.00, 19.00, 14.00, 13.00, 16.00, 18.00, 14.00, 15.00],
    //    [14.00, 15.00, 13.00, 13.00, 15.00, 13.00, 11.00, 16.00, 17.00, 14.00, 19.00, 16.00, 19.00, 16.00, 13.00, 20.00, 17.00, 15.00, 13.00, 14.00, 17.00, 15.00, 18.00, 15.00, 14.00],
    //    [13.00, 13.00, 16.00, 13.00, 16.00, 14.00, 15.00, 17.00, 14.00, 17.00, 14.00, 14.00, 18.00, 13.00, 15.00, 14.00, 15.00, 18.00, 10.00, 16.00, 17.00, 14.00, 17.00, 16.00, 16.00],
    //    [12.00, 15.00, 15.00, 13.00, 14.00, 17.00, 17.00, 14.00, 17.00, 20.00, 15.00, 11.00, 19.00, 15.00, 12.00, 17.00, 13.00, 11.00, 12.00, 14.00, 16.00, 17.00, 17.00, 15.00, 14.00],
    //    [17.00, 17.00, 15.00, 14.00, 17.00, 18.00, 13.00, 14.00, 13.00, 18.00, 17.00, 16.00, 16.00, 13.00, 13.00, 9.00, 15.00, 13.00, 14.00, 13.00, 14.00, 16.00, 13.00, 14.00, 14.00]
    //];

    //var arr_xs = new Array();
    ////初始化，定下有多少行
    //for (i = 0; i < arr[0].length; i++) {
    //    arr_xs[i] = [];
    //}

    //for (var m = 0; m < arr.length; m++) {
    //    for (var n = 0; n < arr[m].length; n++) {
    //        arr_xs[n][m] = arr[m][n];
    //    }
    //}

});

function _js(arr) {

    var sum = 0;
    //自身相乘后再累加
    var sum_all = 0;
    for (var i = 0; i < arr.length; i++) {
        sum += arr[i];
        sum_all += arr[i] * arr[i];
    }
    // var R = Math.max.apply(null, arr) - Math.min.apply(null, arr);
    var X = sum / arr.length;
   


    var S = 0;
    S = Math.sqrt((sum_all - arr.length * X * X) / (arr.length - 1));
    AllSum += X;
    AllAvgSum += S;
    var html = '<td class="sum">' + sum.toFixed(2) + '</td><td class="X">' + X.toFixed(2) + '</td><td class="S">' + S.toFixed(2) + '</td>';
    return html;
}

function fixed2(num) {
    return num.toFixed(2);
}
function fixed3(num) {
    return num.toFixed(3);
}

//paraName 等找参数的名称
function GetUrlParam(paraName) {
    var url = document.location.toString();
    var arrObj = url.split("?");

    if (arrObj.length > 1) {
        var arrPara = arrObj[1].split("&");
        var arr;

        for (var i = 0; i < arrPara.length; i++) {
            arr = arrPara[i].split("=");

            if (arr != null && arr[0] == paraName) {
                return arr[1];
            }
        }
        return "";
    }
    else {
        return "";
    }
}