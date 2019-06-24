$(function () {
    //选择类别
   

    var type = 0;
    //$(".td_select").hide();
   
    $(".btn_select").click(function () {
        $("option").remove();
        $("select").append('<option value="0">请选择</option>');

        $.get("/Select/Index?id=0&type=1", function (data) {
            if (data != null) {
                for (var i = 0; i < data.length; i++) {
                    $("#dpt").append('<option value="' + data[i].DptId + '">' + data[i].DptName + '</option>');
                }
            }
        });

         type = $(this).attr("value");
        if (type == 1) {
            $("#prd").parent().parent().hide();
            $("#pjt").parent().parent().hide();
            $("#set").parent().parent().hide();
        } else if (type == 2) {
            $("#pjt").parent().parent().hide();
            $("#set").parent().parent().hide();
        } else if (type == 3) {
            $("#set").parent().parent().hide();
        } else if (type == 4) {
        }        
        //$(".td_select").show();
    });  

    $('#dpt').change(function () {

        var name = $(this).children('option:selected').text();
        var id = $(this).children('option:selected').val();
        if (type == 1) {
            $("#DepName").val(name);
            $("#depId").val(id);
        } else {
            $.get("/Select/Index?id=" + id + "&type=2", function (data) {
                if (data != null) {
                    for (var i = 0; i < data.length; i++) {
                        $("#prd").append('<option value="' + data[i].PrdId + '">' + data[i].PrdName + '</option>');
                    }
                }
            });
        }
    });
    $('#prd').change(function () {
        var name = $(this).children('option:selected').text();
        var id = $(this).children('option:selected').val();
        if (type == 2) {          
            $("#prd_Name").val(name);
            $("#prd_id").val(id);
        } else {
            $.get("/Select/Index?id=" + id + "&type=3", function (data) {
                if (data != null) {
                    for (var i = 0; i < data.length; i++) {
                        $("#pjt").append('<option value="' + data[i].PjtId + '">' + data[i].PjtName + '</option>');
                    }
                }
            });
        }
    });
    $('#pjt').change(function () {
        var name = $(this).children('option:selected').text();
        var id = $(this).children('option:selected').val();
        if (type == 3) {
            $("#project_Name").val(name);
            $("#project_id").val(id);
        } else {
            $.get("/Select/Index?id=" + id + "&type=4", function (data) {
                if (data != null) {
                    for (var i = 0; i < data.length; i++) {
                        $("#pjt").append('<option value="' + data[i].PjtId + '">' + data[i].PjtName + '</option>');
                    }
                }
            });
        }
    });
});