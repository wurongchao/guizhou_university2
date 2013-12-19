function AdminLoginCheck() {
    var loginName = document.getElementById("LoginName");
    var userPassword = document.getElementById("UserPassword");
    var validCode = document.getElementById("ValidCode");
    if (loginName.value == "") {
        alert("请输入登录名！");
        loginName.focus();
        return false;
    }
    if (userPassword.value == "") {
        alert("请输入密码！");
        userPassword.focus();
        return false;
    }
    return true;
}

function openEdit(obj, width, height) {
    var p = {
        url: obj.href,
        title: obj.innerHTML,
        width: $(this).attr("w") || width,
        height: $(this).attr("h") || height,
        isResize: true
    };
    $.ligerDialog.open(p);
    return true;
}

function closeEdit() {
    location.href = location.href;
}

function closeAdd() {
    location.href = location.pathname + $.query.set("page", 1);
}

function deleteData(id) {
    if (confirm("确认要删除吗？")) { location.href = location.pathname + $.query.set("id", id); }
}

function slideToggle() {
    $("#search").slideToggle();
}

function setPageSize(pageSize) {
    location.href = location.pathname + $.query.set("pageSize", pageSize);
}

function isShowSearch() {
    if ($("#tbKey").val() != "")
        $("#search").show();
}

function IsSelectAll(obj) {
    var ckbArray = $("input[name='DelBox']");
    for (var i = 0; i < ckArray.length; i++) {
        ckbArray[i].checked = obj.checked;
    }
    SetRowBackGroundColor();
}

function SetRowBackroungColor() {
    $("tbody>tr").removeClass("tr");
    $("tbody>tr:has(:checked)").addClass("tr");
}

function DeleteSelected(tableName) {
    var ckbArray = $("input[name='DelBox']:checked");
    if (ckbArray.length == 0) {
        alert("请选择要删除的数据行");
        return false;
    }
    if (!confirm("确认要删除吗？")) return false;
    var ids = "";
    for (var i = 0; i < ckbArray.length; i++) {
        ids = ids + ckbArray[i].value + ",";
    }
    location.href = "DelAll.aspx?t=" + tableName + "&ids=" + ids;
}