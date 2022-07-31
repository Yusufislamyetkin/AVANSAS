var dataTable;

$(document).ready(function () {
    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/GetAll"
        },
        "columns": [
            
            { "data": "name", "width": "15%" },
            { "data": "surName", "width": "12%" },
            { "data": "mail", "width": "13%" },
            { "data": "birthDate", "width": "25%" },
            { "data": "gsmNumber", "width": "5%" },
                
            {

                "data": "encrypedId",
              
               
                "render": function (data) {

                   
                    return `
                       
                            <div class="text-center">
                                <a href="/Admin/UpdateUser/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/DeleteUser/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                         
                           `;
                    
                }, "width": "25%"

                    
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Bu kullanıcıyı silmek istediğinize emin misiniz ?",
        text: "Yaptığınız işlem geri alınamaz !",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        swal({
                            title: "Başarılı !",
                            text: "Kullanıcı başarıyla silindi ",
                            icon: "success",
                            button: "Tamam ",
                        });
                        dataTable.ajax.reload();
                    }
                    else {
                       
                        swal({
                            title: "Başarısız !",
                            text: "Oturum açılan kullanıcı silinemez",
                            icon: "error",
                            button: "Tamam ",
                        });
                        
                    }

                  
                }
            });
        }
    });
}