//$(function() {
//    X();
//    R();
//});

function X() {
    //1,获取值
    var arr = $(".X");
    var arr1 = [];
    arr.each(function() {
        arr1.push($(this).text());
    });
    var canvasX = $("#canvasX")[0];
    var contextX = canvasX.getContext('2d');
    var Max = 1.00, //最大值
        interval = 0.10, //间隔
        Min = 0.40
    var ii = 7,
        jj = arr1.length + 2;
    var hight = 35; //每行的高度
    var width = 30; //每列的宽度
    Draw(contextX, Max, interval, arr1, ii, jj, Min, width, hight);

   // Draw(contextX, x_text, arr1, ii, jj, 0.40);
}

function R() {
    //1,获取值
    var arr = $(".R");
    var arr1 = [];
    arr.each(function() {
        arr1.push($(this).text());
    });
    var canvasR = $("#canvasR")[0];
    var contextR = canvasR.getContext('2d');
   // var num = $("#s_ucl_num").html();
    var Max = 0.50;// Math.ceil(num); //5.00, //最大值
    interval = 0.10, //间隔
        Min = 0;
   // var x_text = 0.50;
    var ii = 6,
        jj = arr1.length + 2;
    var hight = 35; //每行的高度
    var width = 30; //每列的宽度
    Draw(contextR, Max, interval, arr1, ii, jj, Min, width, hight);
    //Draw(contextR, x_text, arr1, ii, jj, 0.00, text);
}

function Draw(cxt, Max, interval, arr1, ii, jj, min, width, hight) {
    cxt.font = "14px 宋体"; //css font属性
    cxt.textBaseline = "middle";
    //画5条线
    var y1, y2;
    var x1 = 50,
        x2 = (jj-1) * width + x1,
        yy = 30;

    for (var i = 0; i < ii; i++) {
        var y = i * hight + yy;

        if (i == 0 || i == ii - 1) {
            if (i == 0) {
                y1 = y;
            } else {
                y2 = y;
            }
            cxt.strokeStyle = "black"; //设置画笔的颜色
        } else if (i == 1 || i == 5) {
            cxt.strokeStyle = "blue";
        } else if (i == 2 || i == 4) {
            cxt.strokeStyle = "red";
        } else if (i == 3) {
            cxt.strokeStyle = "yellow";
        }

        cxt.beginPath(); //开启新路径				
        cxt.lineWidth = 1; //设定画笔的宽度				

        cxt.moveTo(x1, y); //设定笔触的位置				
        cxt.lineTo(x2, y); //设置移动的方式				
        cxt.stroke(); //画线				
        cxt.closePath(); //封闭路径

        //写数字
        var fix = fixed(Max - i * interval);
        cxt.fillText(fix, x1 - 35, y);
    }



    cxt.beginPath(); //开启新路径				
    cxt.lineWidth = 1; //设定画笔的宽度
    cxt.moveTo(x1, y1); //设定笔触的位置				
    cxt.lineTo(x1, y2); //设置移动的方式
    cxt.moveTo(x2, y1); //设定笔触的位置				
    cxt.lineTo(x2, y2); //设置移动的方式				
    cxt.stroke(); //画线				
    cxt.closePath(); //封闭路径

    cxt.textAlign = "center";
    for (var j = 0; j < jj; j++) {
        var x = j * width + x1;
        cxt.beginPath(); //开启新路径				
        cxt.lineWidth = 1; //设定画笔的宽度				
        cxt.strokeStyle = "black"; //设置画笔的颜色
        cxt.moveTo(x, y2 - 3); //设定笔触的位置				
        cxt.lineTo(x, y2); //设置移动的方式				
        cxt.stroke(); //画线				
        cxt.closePath(); //封闭路径

        //写数字
        cxt.fillText(j + 1, x, y2 + 14);
    }
    var p_y;
    for (var k = 0; k < arr1.length; k++) {
        //p_y = (arr1[k] - 0.40) * 10 * 20 + 30;
        var p_y = (ii - 1) * hight + yy - ((arr1[k] - min) / interval * hight);
        arc(cxt, k * width + x1, p_y);
        //划线
        if (k == 0) {

        } else {
            cxt.beginPath(); //开启新路径				
            cxt.lineWidth = 1; //设定画笔的宽度				
            cxt.strokeStyle = "blue"; //设置画笔的颜色
            cxt.moveTo((k - 1) * width + x1, (ii - 1) * hight + yy - ((arr1[k - 1] - min) / interval * hight)); //设定笔触的位置
            cxt.lineTo(k * width + x1, p_y); //设置移动的方式	
            cxt.stroke(); //画线				
            cxt.closePath(); //封闭路径
        }
    }


}

//保留两位小数
function fixed(num) {
    return num.toFixed(2);
}

//在指定的位置上花一个点
function arc(cxt, x, y) {
    cxt.beginPath();
    cxt.fillStyle = "rgb(0,0,255)"; //设置填充的颜色
    cxt.fillRect(x - 2, y - 2, 5, 5);
    cxt.fill();
    cxt.stroke();
    cxt.closePath();
}