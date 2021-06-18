$(document).ready(function () {

    //Pega os dados do banco de dados para preencher o datatable
    var oTable = $("#tbCaes").DataTable({
        oLanguage: { sUrl: "lib/datatables/ptBr.txt" },
        createdRow: function (nRow, aData, meta) {
            $(nRow)
                .attr('data-id', aData.CaesId)
        },
        processing: true,
        filter: true,
        lengthMenu: [[10, 20, 50, -1], [10, 20, 50, "Todos"]],
        pageLength: 20,
        ajax: {
            url: "/Caes/GetCaes",
            type: "GET",
            dataType: "json",
            dataSrc: ""
        },
        columns: [
           
            { data: "Nome" },
           
            {
                data: 'CaesId',
                className: 'text-right',
                render: function (data) {
                    return '<a title="Editar" href="Caes/Edit/' + data + '" class="btn btn-sm btn-outline-primary mr-2"><i class="fas fa-edit"></i></a><a title="Excluir" href="Caes/Delete/' + data + '" class="btn btn-sm btn-outline-danger"><i class="fas fa-trash-alt"></i></a>'
                }
            }
        ]
    });
});