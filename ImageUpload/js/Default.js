
//获取元素，img,文件上传控件
var img = $("#img");
var fuImg = $("#fuImg");
//设置上传控件的change事件
fuImg.change(function () {
    var file = this.files[0];
    //判断文件类型
    if (file.type.indexOf("image") == -1) {
        alert("请选择图片文件！");
        return;
    }
    //判断文件大小
    if (file.size > 1024 * 1024 * 3) {
        alert("图片过大，请选择小于3M的图片");
        return;
    }
    //创建Reader对象
    var reader = new FileReader();
    //通过
    reader.readAsDataURL(file);
    reader.onload = function (fl) {
        var ImgCoding = reader.result;
        //将编码通过ajax返回到asp.net的后台
        $.ajax({
            type: "Post",//请求类型分为post和get
            url: "Default.aspx/SaveImg",//像服务器请求的地址，Default.aspx里面的SaveImg方法
            data: "{ImgCoding:'" + ImgCoding + "'}",//返回参数ImgCoding就是编码的图片
            contentType: "application/json; charset=utf-8",//向服务器发送内容的类型，默认值是：application/x-www-form-urlencoded
            dataType: "json",//预期服务器响应类型
            timeout: '5000',//设置本地的请求超时时间（单位是毫秒）
            //成功后返回执行的方法
            success: function (data) {
                if (data.d != "") {
                    img.attr("src",data.d);
                } else {
                    alert("图片保存失败！");
                }
            },
            //失败后返回执行的方法
            error: function (err) {
                alert("图片上传出错！")
            }
        });
    }
})
