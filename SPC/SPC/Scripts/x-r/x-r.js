$(function () {
    $(".btn").click(function () {
$(this).button('loading').delay(1000).queue(function () {
    $(this).button('reset');
    $(this).dequeue();
});
    });
    $(".div_collapse").click(function () {
var s = $(this).attr("state");
if (s == 1) {
    $(this).attr("state", 0);
    $(this).children().children().text("收起");
} else {
    $(this).attr("state", 1);
    $(this).children().children().text("展开,输入或修改参数");
}
    })



   // var par = [0.65,0.75,0.75,0.60,0.70,0.60,0.75,0.60,0.65,0.60,0.80,0.85,0.70,0.65,0.90,0.75,0.75,0.75,0.65,0.60,0.50,0.60,0.80,0.65,0.65,0.70,0.85,0.80,0.70,0.75,0.75,0.80,0.70,0.80,0.70,0.75,0.75,0.70,0.70,0.80,0.80,0.70,0.70,0.65,0.60,0.55,0.80,0.65,0.60,0.70,0.65,0.75,0.80,0.70,0.65,0.75,0.65,0.80,0.85,0.60,0.90,0.85,0.75,0.85,0.80,0.75,0.85,0.60,0.85,0.65,0.65,0.65,0.75,0.65,0.70,0.65,0.85,0.70,0.75,0.85,0.85,0.75,0.75,0.85,0.80,0.50,0.65,0.75,0.75,0.75,0.80,0.70,0.70,0.65,0.60,0.80,0.65,0.65,0.60,0.60,0.85,0.65,0.75,0.65,0.80,0.70,0.70,0.75,0.75,0.65,0.80,0.70,0.70,0.60,0.85,0.65,0.80,0.60,0.70,0.65,0.80,0.75,0.65,0.70,0.65]
    var par1 = [0.65,0.75,0.75,0.60,0.70,0.60,0.75,0.60,0.65,0.60,0.80,0.85,0.70,0.65,0.90,0.75,0.75,0.75,0.65,0.60,0.50,0.60,0.80,0.65,0.65];
    var par2 = [0.70,0.85,0.80,0.70,0.75,0.75,0.80,0.70,0.80,0.70,0.75,0.75,0.70,0.70,0.80,0.80,0.70,0.70,0.65,0.60,0.55,0.80,0.65,0.60,0.70];
    var par3 = [0.65,0.75,0.80,0.70,0.65,0.75,0.65,0.80,0.85,0.60,0.90,0.85,0.75,0.85,0.80,0.75,0.85,0.60,0.85,0.65,0.65,0.65,0.75,0.65,0.70];
    var par4 = [0.65,0.85,0.70,0.75,0.85,0.85,0.75,0.75,0.85,0.80,0.50,0.65,0.75,0.75,0.75,0.80,0.70,0.70,0.65,0.60,0.80,0.65,0.65,0.60,0.60];
    var par5 = [0.85, 0.65, 0.75, 0.65, 0.80, 0.70, 0.70, 0.75, 0.75, 0.65, 0.80, 0.70, 0.70, 0.60, 0.85, 0.65, 0.80, 0.60, 0.70, 0.65, 0.80, 0.75, 0.65, 0.70, 0.65];

    var _tr = '<tr class="max_width">< td > 1</td><td><input type="text"></td><td><input type="text"></td><td><input type="text"></td><td><input type="text"></td><td><input type="text"></td><td></td><td></td><td></td></tr>';
    var html = "";
    var ii = 0;
    for (var i = 0; i < 25; i++) {
        ii = i + 1;

        html += '<tr class="max_width">';
        html += '<td> ' + ii + '</td >';
        html += '<td><input type="text" value="' + fixed(par1[i]) + '"></td>';
        html += '<td><input type="text" value="' + fixed(par2[i]) + '"></td>';
        html += '<td><input type="text" value="' + fixed(par3[i]) + '"></td>';
        html += '<td><input type="text" value="' + fixed(par4[i]) + '"></td>';
        html += '<td><input type="text" value="' + fixed(par5[i]) + '"></td>';
        //ΣＸ	Ｘ	R

        html += _js(par1[i], par2[i], par3[i], par4[i], par5[i]);
        html += '</tr>';
        $("#parameter").append(html);
        html = "";
        $("#par").hide();
    };
   
   
});

function _js(one, two, thr, fou, fiv) {
    //document.write("最大值为：" + Math.max.apply(null, a) + "<br>");
    //document.write("最小值为：" + Math.min.apply(null, a) + "<br>");
      var arr = new Array(5);
    arr[0] = one;
    arr[1] = two;
    arr[2] = thr;
    arr[3] = fou;
    arr[4] = fiv;
    var sum = one + two + thr + fou + fiv;
    var R = Math.max.apply(null, arr)- Math.min.apply(null, arr);
    var X = sum / arr.length;

    var html = '<td class="sum">' + sum.toFixed(2) + '</td><td class="X">' + X.toFixed(2) + '</td><td class="R">' + R.toFixed(2) + '</td>';
    return html;
}
function fixed(num) {
    return num.toFixed(2);
}

