function confirmEdit(link) {
    var ppm99_stfn_value = $(link).data("ppm99-stfn");
    var confirmed = confirm("Are you sure you want to edit the data number " + ppm99_stfn_value + " ?");
    return confirmed;
}

function confirmDelete(link) {
    var ppm99_stfn_value = $(link).data("ppm99-stfn");
    var confirmed = confirm("Are you sure you want to delete the data number " + ppm99_stfn_value + " ?");
    return confirmed;
}
