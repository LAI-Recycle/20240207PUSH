
function saveForm() {
    var ppm99_stfn_value = $("input[name='ppm99_stfn']").val();

    if (ppm99_stfn_value.length !== 4) {
        alert("The number should be 4 digits.");
        return; 
    }
    $("#submitButton").val("save");
    $("#AddStaffForm").submit();
}

function cancelForm() {
    $("#submitButton").val("cancel");
    $("#AddStaffForm").submit();
}