function onlynumberKey(evt) {
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode
    if (ASCIICode >= 48 && ASCIICode <= 57)//space
        return true

    return false;
}
function onlycharKey(evt) {

    // Only ASCII character in that range allowed
    var ASCIICode = (evt.which) ? evt.which : evt.keyCode
    if (ASCIICode == 59 || ASCIICode == 58)
        return false;
    if (!(ASCIICode > 57) && ASCIICode != 32)
        return false;
    else if (ASCIICode == 124 || ASCIICode == 92 || ASCIICode == 96 || ASCIICode == 95 || ASCIICode == 94 || ASCIICode == 64 || ASCIICode == 126 || ASCIICode == 61)
        return false;
    else if (!(ASCIICode >= 48 && ASCIICode <= 57))//space
        return true
    return true;
}
