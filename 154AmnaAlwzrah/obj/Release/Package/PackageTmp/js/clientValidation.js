function formValidation() {
    var ret = true;
   if (document.getElementById("txtFirstName2").value == "") {
        document.getElementById("lblResult").innerText = "First Name is Required";
        ret = false;
    }
    else {
        document.getElementById("lblResult").innerText = "";
    }
    if (document.getElementById("txtLastName2").value == "") {
        document.getElementById("lblResult").innerText = "Last Name is Required";
        ret = false;
    }
    else {
        document.getElementById("lblResult").innerText = "";
    }
    if (document.getElementById("txtArabic2").value == "") {
        document.getElementById("lblResult").innerText = "Arabic Name is Required";
        ret = false;
    }
    else {
        document.getElementById("lblResult").innerText = "";
    }
    if (document.getElementById("txtBudget2").value == "") {
        document.getElementById("lblResult").innerText = "Budget is Required";
        ret = false;
    }
    else {
        document.getElementById("lblResult").innerText = "";
    }
    return ret;
}



formValidation();