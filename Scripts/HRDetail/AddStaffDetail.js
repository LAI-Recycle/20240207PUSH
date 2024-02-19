
function saveForm() {
    var ppm99_stfn_value = $("input[name='ppm99_stfn']").val();

    if (ppm99_stfn_value.length !== 4) {
        alert("The number should be 4 digits.");
        return; 
    }
    if (CheckStfn(ppm99_stfn_value)) {
        alert("This number already exists.");
        return; 
    }
    $("#submitButton").val("save");
    $("#AddStaffForm").submit();
}

function cancelForm() {
    $("#submitButton").val("cancel");
    $("#AddStaffForm").submit();
}

///檢查員工編號
function CheckStfn(ppm99_stfn_value) {
    var answer;
    $.ajax({
        url: "/HRDetail/CheckStfnDetail",
        type: "POST",
        data: { ppm99_stfn: ppm99_stfn_value },
        dataType: "json",
        async: false,
        success: function (result) {
            answer = result;
        },
        error: function (error) {
            alert(" error " + error.responseText);
        }
    });
    return answer
}