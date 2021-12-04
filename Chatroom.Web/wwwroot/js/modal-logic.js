$('#BtnConsulta').on('click', function () {

    var $cedula = $('#cedulatextbox').val();
  
   if($cedula.length !== 13){
        // alert('Datos incorrectos, por favor, asegúrese de que está introduciendo una cédula válida.');
        $('#validator').text("Datos incorrectos, por favor, asegúrese de que está introduciendo una cédula válida.");

        return false;
   }
   else{
        $('#validator').text("");
        
        if($cedula === '402-2455596-7'){
            $('#good').show();
            $('#bad').hide();
            $('#GenerarTicket').show();
        }
        else{
            $('#good').hide();
            $('#bad').show();
            $('#GenerarTicket').hide();
        }
   }
});