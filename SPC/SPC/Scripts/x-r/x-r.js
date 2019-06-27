//所有的和
var AllSum = 0;
//所有极差的和
var AllAvgSum = 0;

$(function () {
    //$(".btn").click(function () {
    //    $(this).button('loading').delay(1000).queue(function () {
    //        $(this).button('reset');
    //        $(this).dequeue();
    //    });
    //});
    $(".div_collapse").click(function () {
        var s = $(this).attr("state");
        if (s == 1) {
            $(this).attr("state", 0);
            $(this).children().children().text("收起");
        } else {
            $(this).attr("state", 1);
            $(this).children().children().text("展开");
        }
    });

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
                            var ucl_num = AllSum / y + (data.A2) * (AllAvgSum / y);
                            $("#ucl_num").html(fixed2(ucl_num));
                            //中
                            var cl_num = AllSum / y;
                            $("#cl_num").html(fixed2(cl_num));
                            //下
                            var lcl_num = AllSum / y - (data.A2) * (AllAvgSum / y);
                            $("#lcl_num").html(fixed2(lcl_num));

                            //R 上中下
                            //上
                            var s_ucl_num = (data.D4) * (AllAvgSum / y);
                            $("#s_ucl_num").html(fixed2(s_ucl_num));
                            //中
                            var s_cl_num = AllAvgSum / y;
                            $("#s_cl_num").html(fixed2(s_cl_num));
                            //下
                            var s_lcl_num = (data.D3) * (AllAvgSum / y);
                            $("#s_lcl_num").html(fixed2(s_lcl_num));
                            //画图
                            X();
                            R();
                        }
                    });

                }
            });
        }
    });


   //// var par = [0.65,0.75,0.75,0.60,0.70,0.60,0.75,0.60,0.65,0.60,0.80,0.85,0.70,0.65,0.90,0.75,0.75,0.75,0.65,0.60,0.50,0.60,0.80,0.65,0.65,0.70,0.85,0.80,0.70,0.75,0.75,0.80,0.70,0.80,0.70,0.75,0.75,0.70,0.70,0.80,0.80,0.70,0.70,0.65,0.60,0.55,0.80,0.65,0.60,0.70,0.65,0.75,0.80,0.70,0.65,0.75,0.65,0.80,0.85,0.60,0.90,0.85,0.75,0.85,0.80,0.75,0.85,0.60,0.85,0.65,0.65,0.65,0.75,0.65,0.70,0.65,0.85,0.70,0.75,0.85,0.85,0.75,0.75,0.85,0.80,0.50,0.65,0.75,0.75,0.75,0.80,0.70,0.70,0.65,0.60,0.80,0.65,0.65,0.60,0.60,0.85,0.65,0.75,0.65,0.80,0.70,0.70,0.75,0.75,0.65,0.80,0.70,0.70,0.60,0.85,0.65,0.80,0.60,0.70,0.65,0.80,0.75,0.65,0.70,0.65]
   // var par1 = [0.65,0.75,0.75,0.60,0.70,0.60,0.75,0.60,0.65,0.60,0.80,0.85,0.70,0.65,0.90,0.75,0.75,0.75,0.65,0.60,0.50,0.60,0.80,0.65,0.65];
   // var par2 = [0.70,0.85,0.80,0.70,0.75,0.75,0.80,0.70,0.80,0.70,0.75,0.75,0.70,0.70,0.80,0.80,0.70,0.70,0.65,0.60,0.55,0.80,0.65,0.60,0.70];
   // var par3 = [0.65,0.75,0.80,0.70,0.65,0.75,0.65,0.80,0.85,0.60,0.90,0.85,0.75,0.85,0.80,0.75,0.85,0.60,0.85,0.65,0.65,0.65,0.75,0.65,0.70];
   // var par4 = [0.65,0.85,0.70,0.75,0.85,0.85,0.75,0.75,0.85,0.80,0.50,0.65,0.75,0.75,0.75,0.80,0.70,0.70,0.65,0.60,0.80,0.65,0.65,0.60,0.60];
   // var par5 = [0.85, 0.65, 0.75, 0.65, 0.80, 0.70, 0.70, 0.75, 0.75, 0.65, 0.80, 0.70, 0.70, 0.60, 0.85, 0.65, 0.80, 0.60, 0.70, 0.65, 0.80, 0.75, 0.65, 0.70, 0.65];



    //var _tr = '<tr class="max_width">< td > 1</td><td><input type="text"></td><td><input type="text"></td><td><input type="text"></td><td><input type="text"></td><td><input type="text"></td><td></td><td></td><td></td></tr>';
    //var html = "";
    //var ii = 0;
    //for (var i = 0; i < 25; i++) {
    //    ii = i + 1;

    //    html += '<tr class="max_width">';
    //    html += '<td> ' + ii + '</td >';
    //    html += '<td><input type="text" value="' + fixed2(par1[i]) + '"></td>';
    //    html += '<td><input type="text" value="' + fixed2(par2[i]) + '"></td>';
    //    html += '<td><input type="text" value="' + fixed2(par3[i]) + '"></td>';
    //    html += '<td><input type="text" value="' + fixed2(par4[i]) + '"></td>';
    //    html += '<td><input type="text" value="' + fixed2(par5[i]) + '"></td>';
    //    //ΣＸ	Ｘ	R

    //    html += _js(par1[i], par2[i], par3[i], par4[i], par5[i]);
    //    html += '</tr>';
    //    $("#parameter").append(html);
    //    html = "";
    //    $("#par").hide();
    //};
   
   
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
    var R = Math.max.apply(null, arr) - Math.min.apply(null, arr);
    var X = sum / arr.length;

    AllSum += X;
    AllAvgSum += R;
    //var html = '<td class="sum">' + sum.toFixed(2) + '</td><td class="X">' + X.toFixed(2) + '</td><td class="S">' + S.toFixed(2) + '</td>';
    var html = '<td class="sum">' + sum.toFixed(2) + '</td><td class="X">' + X.toFixed(2) + '</td><td class="R">' + R.toFixed(2) + '</td>';
    return html;
}
//function _js(one, two, thr, fou, fiv) {
//    //document.write("最大值为：" + Math.max.apply(null, a) + "<br>");
//    //document.write("最小值为：" + Math.min.apply(null, a) + "<br>");
//      var arr = new Array(5);
//    arr[0] = one;
//    arr[1] = two;
//    arr[2] = thr;
//    arr[3] = fou;
//    arr[4] = fiv;
//    var sum = one + two + thr + fou + fiv;
   

//    var html = '<td class="sum">' + sum.toFixed(2) + '</td><td class="X">' + X.toFixed(2) + '</td><td class="R">' + R.toFixed(2) + '</td>';
//    return html;
//}

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