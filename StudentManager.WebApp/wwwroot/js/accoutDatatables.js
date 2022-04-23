function onFormSubmitCreate() {
	$('#frmCreate').on("submit", function () {
		var UserName = $("#Usename").val();
		var email = $("#email").val();
		var password = $("#password").val();
		var rePassword = $("#rePassword").val();
		var isValid = true;
		if (UserName == "") {
			$("span[data-valmsg-for = 'UserName']").text("This field is require !");
			$("span[data-valmsg-for = 'UserName']").css('color', 'red');
			isValid = false;
		}
		if (email == "") {
			$("span[data-valmsg-for = 'Email']").text("This field is require !");
			$("span[data-valmsg-for = 'Email']").css('color', 'red');
			isValid = false;
		}
		if (password == "") {
			$("span[data-valmsg-for = 'Password']").text("This field is require !");
			$("span[data-valmsg-for = 'Password']").css('color', 'red');
			isValid = false;
		}

		return isValid;

	});
}