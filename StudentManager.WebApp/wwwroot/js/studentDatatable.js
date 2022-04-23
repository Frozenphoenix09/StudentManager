$(document).ready(function() {
	$('#studentTable').dataTable({
		"processing": true,
		"serverSide": true,
		"filter": true,
		"ajax": {
			"url": "/student/getstudents",
			"type": "POST",
			"datatype": "json"
		},
		"columnDefs": [{
			"targets": [0],
			"visible": false,
			"searchable": false
		}],
		"columns": [
			{ "data": "studentId" },
			{ "data": "name", "name": "Name" },
			{
				"render": function (data, type, row) { return '<span>' + row.dateOfBirth.split('T')[0] + '</span>' },
				"name": "DateOfBirth"
			},
			{ "data": "address", "name": "Address" },
			{
				"data":"classesName[]",
			},
			{
				"render": function (data, type, row) { return '<a href="/Student/Edit?studentId=' + row.studentId + '" class="btn btn-warning">Edit</a>' + " " + '<a href="/Student/Delete?studentId=' + row.studentId +'" class="btn btn-danger">Delete</a>' },
				"orderable": false,
				"autowidth": true
			}
		]
	});
});

function onFormSubmitCreate() {
	$('#frmCreate').on("submit", function () {
		var name = $("#name").val();
		var address = $("#address").val();
		var dateOfBirth = $("#dateOfBirth").val();
		var isValid = true;
		if (name == "") {
			$("span[data-valmsg-for = 'Name']").text("This field is require !");
			$("span[data-valmsg-for = 'Name']").css('color', 'red');
			isValid = false;
		}
		if (address == "") {
			$("span[data-valmsg-for = 'Address']").text("This field is require !");
			$("span[data-valmsg-for = 'Address']").css('color', 'red');
			isValid = false;
		}
		if (dateOfBirth == "") {
			$("span[data-valmsg-for = 'DateOfBirth']").text("This field is require !");
			$("span[data-valmsg-for = 'DateOfBirth']").css('color', 'red');
			isValid = false;
		}

		return isValid;

	});
}
