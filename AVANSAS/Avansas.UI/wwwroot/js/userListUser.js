var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/User/GetAll"
        },
        "columns": [
            
            { "data": "name", "width": "25%" },
            { "data": "surName", "width": "25%" },
            { "data": "mail", "width": "25%" },
            { "data": "birthDate", "width": "10%" },
            { "data": "gsmNumber", "width": "10%" }

            
          
                
           
        ]
    });
}

