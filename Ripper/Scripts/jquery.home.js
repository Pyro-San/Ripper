$(document).ready(function () {
	// handle adding a board
	$('#AddBoard').on('click', function () {
		var multi = $('#bmult').val();
		console.log(multi);
		console.log($('#BoardList'));
		if (multi > 0) {
			for (var i = 0; i < multi; i++) {
				$('#BoardList').append("<option value='" + $('#StdBoards').val() + "'>" + $('#StdBoards').val() + "</option>");
			}
		}
		$('#bmult').val(1);
		return false;
	});
	// handle removing a board
    $('#RemBoard').on('click', function() {
        $('#BoardList option:selected').each(function() {
            this.remove();
        });
    });

	// handle adding a required length
	$('#AddLeng').on('click', function () {
		var multi = $('#lmult').val();
		if (multi > 0) {
			for (var i = 0; i < multi; i++) {
				$('#LengthList').append("<option value='" + $('#leng').val() + "'>" + $('#leng').val() + "</option>");
			}
		}
		$('#leng').val('');
		$('#lmult').val(1);
		return false;
	});

	// handle removing a required length
	$('#RemLeng').on('click', function () {
		$('#LengthList option:selected').each(function () {
			this.remove();
		});
	});


	// handle submittion
	$('#sub').on('click', function () {
		$('#BoardList option').attr('selected', 'selected');
		$('#LengthList option').attr('selected', 'selected');
		//$('form').validate();
		$('#CutForm').submit();
	});

});
