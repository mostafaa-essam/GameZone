$.validator.addMethod('fileSize', function (value, element, parameter) {
    var isValid = this.optional(element) || element.files[0].size <= parameter;
    return isValid;
});