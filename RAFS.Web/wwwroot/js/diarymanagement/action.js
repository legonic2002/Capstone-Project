$(document).ready(function () {
    typeid = checkParameterType();
    var plantid = checkParameter();
    const elements = document.querySelectorAll('.backbtn');

    // Loop through each element
    elements.forEach(element => {
        // Set the href attribute
        element.setAttribute('href', '/plant?plantid=' + plantid+"#");
    });
    if (typeid != 0) {
        if (typeid == 1) {
            document.getElementById("profile").checked = true;
            document.getElementById("settings").checked = false;

            document.getElementById("posts").checked = false;
            // Check the settings id
           
        }
        if (typeid == 2) {
            document.getElementById("profile").checked = false;

            document.getElementById("settings").checked = true;

            document.getElementById("posts").checked = false;
          
            
        }
        if (typeid == 3) {
            document.getElementById("profile").checked = false;

            
            // Check the settings id
            document.getElementById("settings").checked = false;

            document.getElementById("posts").checked = true;
        }


    }
    $("#profile").on('click', function () {
        currentpage = 1;
        updatePaginationButtons(currentpage, totalPages1);
        var id3 = '#table1 tbody';

        $(id3).empty().append(getElementsByPage1(currentpage));
        updatePaginationButtons(currentpage, totalPages1);

    });
    $("#settings").on('click', function () {
        currentpage = 1;
        updatePaginationButtons(currentpage, totalPages2);
        var id3 = '#table2 tbody';

        $(id3).empty().append(getElementsByPage2(currentpage));
        updatePaginationButtons(currentpage, totalPages2);
    });
    $("#posts").on('click', function () {
        currentpage = 1;
        updatePaginationButtons(currentpage, totalPages3);
        var id3 = '#table3 tbody';

        $(id3).empty().append(getElementsByPage(currentpage));
        updatePaginationButtons(currentpage, totalPages3);

    });

    $('#pagi-pages').on('click', 'a.page-link', function () {
        if ($(this).attr('id') === 'prevPage') {
            console.log("go pre");
            if (currentpage > 1) {
                currentpage--;
                if (document.getElementById("profile").checked == true) {
                    var id3 = '#table1 tbody';

                    $(id3).empty().append(getElementsByPage1(currentpage));
                    updatePaginationButtons(currentpage, totalPages1);
                }
                if (document.getElementById("settings").checked == true) {
                    var id3 = '#table2 tbody';

                    $(id3).empty().append(getElementsByPage2(currentpage));
                    updatePaginationButtons(currentpage, totalPages2);
                }
                if (document.getElementById("posts").checked == true) {
                    var id3 = '#table3 tbody';

                    $(id3).empty().append(getElementsByPage(currentpage));
                    updatePaginationButtons(currentpage, totalPages3);
                }
                // Check the settings id


            }
        } else if ($(this).attr('id') === 'nextPage') {
            var total = 0;
            if (document.getElementById("profile").checked == true) {
                total = totalPages1;
            }

            if (document.getElementById("posts").checked == true) {
                total = totalPages3;
            }
            // Check the settings id
            if (document.getElementById("settings").checked == true) {
                total = totalPages2;
            }

            if (currentpage < total) {
                currentpage++;
                if (document.getElementById("profile").checked == true) {
                    var id3 = '#table1 tbody';

                    $(id3).empty().append(getElementsByPage1(currentpage));
                    updatePaginationButtons(currentpage, totalPages1);
                }
                if (document.getElementById("settings").checked == true) {
                    var id3 = '#table2 tbody';

                    $(id3).empty().append(getElementsByPage2(currentpage));
                    updatePaginationButtons(currentpage, totalPages2);
                }
                if (document.getElementById("posts").checked == true) {
                    var id3 = '#table3 tbody';

                    $(id3).empty().append(getElementsByPage(currentpage));
                    updatePaginationButtons(currentpage, totalPages3);
                }
            }
        } else {
            currentpage = parseInt($(this).text());
            updatePaginationButtons(currentpage, totalPages3);
        }
        if (document.getElementById("profile").checked == true) {
            var id3 = '#table1 tbody';

            $(id3).empty().append(getElementsByPage1(currentpage));
            updatePaginationButtons(currentpage, totalPages1);
        }
        if (document.getElementById("settings").checked == true) {
            var id3 = '#table2 tbody';

            $(id3).empty().append(getElementsByPage2(currentpage));
            updatePaginationButtons(currentpage, totalPages2);
        }
        if (document.getElementById("posts").checked == true) {
            var id3 = '#table3 tbody';

            $(id3).empty().append(getElementsByPage(currentpage));
            updatePaginationButtons(currentpage, totalPages3);
        }

    });


    $('#profile2').on('click', function () { typeid = 1 });
    $('#settings2').on('click', function () { typeid = 2 });
    $('#posts2').on('click', function () { typeid = 3 });
    Manager.GetAllProduct();
    $("table").on("click", ".deleteffff", function (e) {
        var resId = $(this).attr("id");
        console.log("click");
        $("#myModal").modal();
        var rows = "";
        rows += ` <tr class="milestone" id=milestoneofplant'${resId}' >
                                            <td>
                                            <h3>Việc xóa bản ghi này có thể sẽ không được khôi phục và các dữ liệu liên quan cũng sẽ biến mất (trừ dữ liệu trang QR)</h3>
                                            </td>
                                        </tr>`;
        $('#plantlist').empty().append(rows);
        
    });
    function Delete(resId) {
        $.ajax({
            url: baseUrl + "Diary/DeleteDiary?milestoneId=" + resId,
            type: "delete",
            contentType: "application/json",
            success: function (result, status, xhr) {

                createToast('success', 'fa-solid fa-circle-check', 'Success', 'Xóa thành công');

                var id2 = '#table2 tbody';
                $(id2).empty();
                id2 = '#table1 tbody';
                $(id2).empty();
                id2 = '#table3 tbody';
                $(id2).empty();
                setTimeout(function () {
                    Manager.GetAllProduct();
                }, 1000);

                window.location = "/diary?plantid=" + checkParameter() + "&type=" + checkParameterType() + "#";


            },
            error: function (xhr, status, error) {
                createToast('error', 'fa-solid fa-circle-exclamation', 'Error', error.message);
                pauseExecution(1000);

            }

        });

    }
    $('#deletebtn').on('click', function () {
        var elements = document.getElementsByClassName("milestone");
        var id = elements[0].id;

        var resId = id;
        resId = resId.slice(16);

        resId = resId.replace(/\D/g, '');
        resId = parseInt(resId);
        console.log(resId);
        Delete(resId);
    });
    document.getElementById("update").onclick = function () { Update() };
    document.getElementById("add").onclick = function () { Create() };
    document.getElementById("createbtn").onclick = function () {
        $("#PlantId").val(checkParameter());
        HideOption(1);
        document.getElementById("Title").value = null;
        document.getElementById("Body").value = null;
        document.getElementById("Image").value = null;

    };
    document.getElementById("createbtn2").onclick = function () {
        $("#PlantId").val(checkParameter());
        HideOption(2);
        document.getElementById("Title").value = null;
        document.getElementById("Body").value = null;
        document.getElementById("Image").value = null;

    };
    document.getElementById("createbtn3").onclick = function () {
        $("#PlantId").val(checkParameter());
        HideOption(3);
        document.getElementById("Title").value = null;
        document.getElementById("Body").value = null;
        document.getElementById("Image").value = null;

    };
    const generateHtmlForm = (data) => {
        let dataGrid = '';

        data.forEach(element => {
            var dateString = element.lastUpdate;
            var date = new Date(dateString);

            // Lấy ngày, tháng và năm từ đối tượng ngày
            var day = date.getDate();
            var month = date.getMonth() + 1; // Tháng bắt đầu từ 0 nên cần cộng thêm 1
            var year = date.getFullYear();

            // Định dạng lại chuỗi ngày theo định dạng mong muốn
            var formattedDate = day + "/" + month + "/" + year;

            // Kiểm tra status và gán label tương ứng
            let statusLabel = '';

            statusLabel = `<label class="badge badge-success">${element.numberOfPlants}</label>`;


            var formid = element.id;
            dataGrid +=
                `
                                            <tr id=milestone'${element.id}'>
                                        <td>${element.id}</td>
                                        <td>${element.name}</td>
                                        <td>${element.description}</td>
                                <td>${formattedDate}</td>
                                <td>${statusLabel}</td>
                                <td>
                                  <i id = 'demo'  class='material-icons deleteffff pure2' style='font-size:48px;'>delete</i>
                                </td>
                            </tr>
                            `;
        });

        return dataGrid;
    };

    // Xử lý sự kiện click cho nút "Chi tiết"


    const generateHtmlQuestionContent = (data) => {
        return `
                         <p>${data.description} </p>
                    `;
    };

    const generateHtmlFormStatus = (data) => {
        let option1 = '';
        let option2 = '';

        // Kiểm tra trạng thái của data.status và thiết lập option selected tương ứng
        if (data.status === false) {
            option1 = '<option value="false" selected>Chưa đọc</option>';
            option2 = '<option value="true">Đã trả lời</option>';
        } else {
            option1 = '<option value="false">Chưa đọc</option>';
            option2 = '<option value="true" selected>Đã trả lời</option>';
        }

        return `
                        <label for="exampleFormControlSelect1">Trạng thái</label>
                        <select class="form-control" id="exampleFormControlSelect1">
                            ${option1}
                            ${option2}
                        </select>
                    `;
    };

    const generateHtmlModalsBtn = (data) => {
        const formid = data.id; // Lấy formid từ dữ liệu

        return `
                         <button type="button" class="btn btn-secondary" data-dismiss="modal">Đóng</button>
                         <button id="saveStatus" class="btn btn-primary updateStatusBtn" data-formid="${formid}">Cập nhật</button>
                         
                    `;

    };


    document.getElementById('sortBtn').addEventListener('click', function () {
        // Retrieve selected sort optionsz
        var searchInput = document.getElementById('searchName').value.trim();
        if (searchInput.length > 60) {
            document.getElementById("search-toast").innerHTML = 'Tiêu đề không được nhiều hơn 60 kí tự ';

        } else {
            var healSort = document.getElementById('healFilter').value;


            console.log(StorestringArray12);
            console.log(StorestringArray10);
            console.log(StorestringArray18);
            var list;
            if (document.getElementById("profile").checked == true) {
                console.log("go 1");
                list = StorestringArray10;
            }
            if (document.getElementById("settings").checked == true) {
                console.log("go 2");
                list = StorestringArray12;
            }

            if (document.getElementById("posts").checked == true) {
                console.log("go 3");
                list = StorestringArray18;
            }
            console.log(list);
            var acceptable1 = true;
            var acceptable2 = true;
            if (searchInput === '' || searchInput.length == 0) {
                acceptable1 = false;
            }
            if (healSort == '0') {
                acceptable2 = false;
            }
            function compare(a, b) {
                return a.localeCompare(b);
            }
            console.log(acceptable1);
            console.log(acceptable2);
            if (acceptable1 && acceptable2) {
                list = list.filter(function (obj) {
                    return obj.title.toLowerCase().includes(searchInput.toLowerCase());
                });
                list.sort(function (a, b) {
                    var aDate = new Date(a.lastUpdate);
                    var bDate = new Date(b.lastUpdate);

                    if (healSort === 'Tăng') {
                        return aDate - bDate;
                    } else {
                        return bDate - aDate;
                    }
                });
            }
            if (acceptable1 == false && acceptable2) {

                list.sort(function (a, b) {
                    var aDate = new Date(a.lastUpdate);
                    var bDate = new Date(b.lastUpdate);

                    if (healSort === 'Tăng') {
                        return aDate - bDate;
                    } else {
                        return bDate - aDate;
                    }
                });

            }
            if (acceptable1 && acceptable2 == false) {
                list = list.filter(function (obj) {
                    return obj.title.toLowerCase().includes(searchInput.toLowerCase());
                });
            }


            if (acceptable1 == false && acceptable2 == false) {
                Manager.GetAllProduct();
            }

            console.log(list);
            if (document.getElementById("profile").checked == true) {
                resetData(list, 1);
            }
            if (document.getElementById("settings").checked == true) {
                resetData(list, 2);
            }
            if (document.getElementById("posts").checked == true) {
                resetData(list, 3);
            }


        }


    });
    document.getElementById('resetBtn').addEventListener('click', function () {
        document.getElementById('searchName').value = "";
        document.getElementById('healFilter').value = 0;

        Manager.GetAllProduct();
    });
    
})
