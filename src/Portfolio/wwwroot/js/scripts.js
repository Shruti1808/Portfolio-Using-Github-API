$(document).ready(function () {


    $.ajax({
        type: 'GET',
        dataType: 'json',
        data: $(this).serialize(),
        url: 'Home/GetProjects',
        success: function (result) {
            $('#result').html(result);  
        }
    });
 });