$(document).ready(function () {
    Manager.GetAllItems(0);

    var typeid = checkParameterType();
    var plantid = checkParameter();
    const elements = document.querySelectorAll('.backbtn');

    // Loop through each element
    elements.forEach(element => {
        element.setAttribute('href', '/plant?plantid=' + plantid + "#" );
    });
    if (typeid != 0) {
        if (typeid == 1) {
            document.getElementById("profile").checked = true;

            document.getElementById("posts").checked = false;
            // Check the settings id
            document.getElementById("settings").checked = false;
        }
        if (typeid == 2) {
            document.getElementById("profile").checked = false;

            document.getElementById("settings").checked = true;

            document.getElementById("posts").checked = false;
            // Check the settings id
            
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
            url: baseUrl + "PlantMaterialHistory/DeletePlantMaterialRecord?milestoneId=" + resId,
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

                window.location = "/materialhistory?plantid=" + checkParameter() + "&type=" + checkParameterType() + "#";


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
    document.getElementById("add").onclick = function () { Create() };
    document.getElementById("update").onclick = function () { Update() };
    
    document.getElementById("createbtn").onclick = function () {

        $("#InventoryId option[value='0']").prop("selected", true);
        $("#UnitName option[value='0']").prop("selected", true);
        $("#PlantId").val(checkParameter());

        Manager.GetAllItems(1);


        
    };
    document.getElementById("createbtn2").onclick = function () {
        $("#InventoryId option[value='0']").prop("selected", true);
        $("#UnitName option[value='0']").prop("selected", true);
        $("#PlantId").val(checkParameter());
        Manager.GetAllItems(2);
        
    };
    document.getElementById("createbtn3").onclick = function () {
        $("#InventoryId option[value='0']").prop("selected", true);
        $("#UnitName option[value='0']").prop("selected", true);
        $("#PlantId").val(checkParameter());
        Manager.GetAllItems(3);
      
    };
    document.getElementById('sortBtn').addEventListener('click', function () {
        // Retrieve selected sort optionsz
        var searchInput = document.getElementById('searchName').value.trim();
        if (searchInput.length > 60) {
            document.getElementById("search-toast").innerHTML = 'Tên của vật phẩm không được nhiều hơn 60 kí tự ';

        } else {
            var healSort = document.getElementById('healFilter').value;
            var typeSort = document.getElementById('typeFilter').value;

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
            var acceptable1 = true;
            var acceptable2 = true;
            var acceptable3 = true;
            if (searchInput === '' || searchInput.length == 0) {
                acceptable1 = false;
            }
            if (healSort == '0') {
                acceptable2 = false;
            }
            if (typeSort == '0') {
                acceptable3 = false;
            }
            function compare(a, b) {
                return a.localeCompare(b);
            }

            if (acceptable1 && acceptable2 && acceptable3) {
                list = list.filter(function (obj) {
                    return obj.inventoryName.toLowerCase().includes(searchInput.toLowerCase());
                });
                list.sort(function (a, b) {
                    var aDate = new Date(a.lastUpdate).toLocaleDateString();
                    var bDate = new Date(b.lastUpdate).toLocaleDateString();

                    if (healSort === 'Tăng') {
                        if (aDate === bDate) {
                            if (typeSort === 'Giảm') {
                                return parseInt(b.quality) - parseInt(a.quality);
                            } else {
                                return parseInt(a.quality) - parseInt(b.quality);
                            }
                        }
                        return new Date(a.lastUpdate) - new Date(b.lastUpdate);
                    } else {
                        if (aDate === bDate) {
                            if (typeSort === 'Giảm') {
                                return parseInt(b.quality) - parseInt(a.quality);
                            } else {
                                return parseInt(a.quality) - parseInt(b.quality);
                            }
                        }
                        return new Date(b.lastUpdate) - new Date(a.lastUpdate);
                    }
                });

            }
            if (acceptable1 == false && acceptable2 && acceptable3) {

                list.sort(function (a, b) {
                    var aDate = new Date(a.lastUpdate).toLocaleDateString();
                    var bDate = new Date(b.lastUpdate).toLocaleDateString();

                    if (healSort === 'Tăng') {
                        if (aDate === bDate) {
                            if (typeSort === 'Giảm') {
                                return parseInt(b.quality) - parseInt(a.quality);
                            } else {
                                return parseInt(a.quality) - parseInt(b.quality);
                            }
                        }
                        return new Date(a.lastUpdate) - new Date(b.lastUpdate);
                    } else {
                        if (aDate === bDate) {
                            if (typeSort === 'Giảm') {
                                return parseInt(b.quality) - parseInt(a.quality);
                            } else {
                                return parseInt(a.quality) - parseInt(b.quality);
                            }
                        }
                        return new Date(b.lastUpdate) - new Date(a.lastUpdate);
                    }
                });


            }
            if (acceptable1 && acceptable2 == false && acceptable3) {
                list = list.filter(function (obj) {
                    return obj.inventoryName.toLowerCase().includes(searchInput.toLowerCase());
                });
                list.sort(function (a, b) {
                    if (typeSort === 'Giảm') {
                        return parseInt(b.quality) - parseInt(a.quality);
                    } else {
                        return parseInt(a.quality) - parseInt(b.quality);
                    }
                });
            }
            if (acceptable1 && acceptable2 && acceptable3 == false) {
                list = list.filter(function (obj) {
                    return obj.inventoryName.toLowerCase().includes(searchInput.toLowerCase());
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
            if (acceptable1 == false && acceptable2 == false && acceptable3) {
                list.sort(function (a, b) {
                    if (typeSort === 'Giảm') {
                        return parseInt(b.quality) - parseInt(a.quality);
                    } else {
                        return parseInt(a.quality) - parseInt(b.quality);
                    }
                });
            }
            if (acceptable1 && acceptable2 == false && acceptable3 == false) {
                list = list.filter(function (obj) {
                    return obj.inventoryName.toLowerCase().includes(searchInput.toLowerCase());
                });

            }
            if (acceptable1 == false && acceptable2 && acceptable3 == false) {
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
            if (acceptable1 == false && acceptable2 == false && acceptable3 == false) {
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
        document.getElementById('typeFilter').value = 0;

        Manager.GetAllProduct();
    });

})
function resetData(jsonData, type) {
    if (type == 1) {
        console.log("go 10" );
        stringArray10 = [];
      
    }
    if (type == 2) {
        console.log("go  12" );
        stringArray12 = [];
        
    } if (type == 3) {
        console.log("go 18");
        stringArray18 = [];
    }
   
    var rows1 = "";
    var rows2 = "";
    var rows3 = "";
    $.each(jsonData, function (i, item) {

        var mydate = new Date(item.lastUpdate);
        var options = { year: 'numeric', month: 'long', day: 'numeric' };
        let text = mydate.toLocaleDateString('vi-VN', options);

        var datetimeString = item.lastUpdate;

        // Parse the datetime string into a Date object
        var targetDatetime = new Date(datetimeString);

        // Add 1 day to the target datetime
        var oneDayLater = new Date(targetDatetime);
        oneDayLater.setDate(oneDayLater.getDate() + 1);

        // Check if the current datetime is greater than 1 day after the target datetime
        var isGreaterThanOneDay = Date.now() >= oneDayLater.getTime();
        if (type == 2) {
            if (isGreaterThanOneDay == true) {
                rows2 = "<tr id='" + item.id + "' class='detail-option' onclick='detail11(event)'>" +
                    "<td hidden><a href='#' class='detail1 detail-option' onclick='detail11(event)'>" + item.id + "</a></td>" +
                    "<td><a href='#' class='detail1 detail-option' onclick='detail11(event)'>" + item.inventoryName + "</a></td>" +
                    "<td><a href='#' class='detail1 detail-option' onclick='detail11(event)'>" + item.plantName + "</a></td>" +
                    "<td><a href='#' class='detail1 detail-option' onclick='detail11(event)'><label class='badge badge-info'>" + item.quality + "</label></a></td>" +
                    "<td><a href='#' class='detail1 detail-option' onclick='detail11(event)'>" + text + "</a></td>" +
                    "<td>" +
                    "</td>" +
                    "</tr>";
                stringArray12.push(rows2);
            } else {
                rows2 =

                    "<tr id='" + item.id + "' class='detail-option' onclick='detail11(event)'>" +
                    "<td hidden><a href='#popup2' class='detail1 detail-option' onclick='detail11(event)'>" + item.id + "</a></td>" +
                    "<td><a href='#popup2' class='detail1 detail-option' onclick='detail11(event)'>" + item.inventoryName + "</a></td>" +
                    "<td><a href='#popup2' class='detail1 detail-option' onclick='detail11(event)'>" + item.plantName + "</a></td>" +
                    "<td><a href='#popup2' class='detail1 detail-option' onclick='detail11(event)'><label class='badge badge-info'>" + item.quality + "</label></a></td>" +
                    "<td><a href='#popup2' class='detail1 detail-option' onclick='detail11(event)'>" + text + "</a></td>" +
                    "<td>" +
                    "<button style='border-style: none; background-color:white;'> <i id='" + item.id + "' class='material-icons deleteffff pure2' style='font-size: 28px;color: black;background-color: floralwhite;height: 25px; '>delete</i> </button>" +
                    "</td>" +
                    "</tr>";
                stringArray12.push(rows2);
            }

        }
        if (type == 3) {
            if (isGreaterThanOneDay == true) {
                rows3 = "<tr id='" + item.id + "' class='detail-option' onclick='detail33(event)'>" +
                    "<td hidden><a href='#' class='detail3 detail-option' onclick='detail33(event)'>" + item.id + "</a></td>" +
                    "<td><a href='#' class='detail3 detail-option' onclick='detail33(event)'>" + item.inventoryName + "</a></td>" +
                    "<td><a href='#' class='detail3 detail-option' onclick='detail33(event)'>" + item.plantName + "</a></td>" +
                    "<td><a href='#' class='detail3 detail-option' onclick='detail33(event)'><label class='badge badge-info'>" + item.quality + "</label></a></td>" +
                    "<td><a href='#' class='detail3 detail-option' onclick='detail33(event)'>" + text + "</a></td>" +
                    "<td>" +
                    "</td>" +
                    "</tr>";
                stringArray18.push(rows3);
            } else {
                rows3 = "<tr id='" + item.id + "' class='detail-option' onclick='detail33(event)'>" +
                    "<td hidden><a href='#popup2' class='detail3 detail-option' onclick='detail33(event)'>" + item.id + "</a></td>" +
                    "<td><a href='#popup2' class='detail3 detail-option' onclick='detail33(event)'>" + item.inventoryName + "</a></td>" +
                    "<td><a href='#popup2' class='detail3 detail-option' onclick='detail33(event)'>" + item.plantName + "</a></td>" +
                    "<td><a href='#popup2' class='detail3 detail-option' onclick='detail33(event)'><label class='badge badge-info'>" + item.quality + "</label></a></td>" +
                    "<td><a href='#popup2' class='detail3 detail-option' onclick='detail33(event)'>" + text + "</a></td>" +
                    "<td>" +
                    "<button style='border-style: none; background-color:white;'> <i id='" + item.id + "' class='material-icons deleteffff pure2' style='font-size: 28px;color: black;background-color: floralwhite;height: 25px; '>delete</i> </button>" +
                    "</td>" +
                    "</tr>";
                stringArray18.push(rows3);
            }

        }
        if (type == 1) {
            if (isGreaterThanOneDay == true) {
                rows1 = "<tr id='" + item.id + "' class='detail-option' onclick='detail22(event)'>" +
                    "<td hidden><a href='#' class='detail2 detail-option' onclick='detail22(event)'>" + item.id + "</a></td>" +
                    "<td><a href='#' class='detail2 detail-option' onclick='detail22(event)'>" + item.inventoryName + "</a></td>" +
                    "<td><a href='#' class='detail2 detail-option' onclick='detail22(event)'>" + item.plantName + "</a></td>" +
                    "<td><a href='#' class='detail2 detail-option' onclick='detail22(event)'><label class='badge badge-info'>" + item.quality + "</label></a></td>" +
                    "<td><a href='#' class='detail2 detail-option' onclick='detail22(event)'>" + text + "</a></td>" +
                    "<td>" +
                    "</td>" +
                    "</tr>";
                stringArray10.push(rows1);
            } else {
                rows1 = "<tr id='" + item.id + "' class='detail-option' onclick='detail22(event)'>" +
                    "<td hidden><a href='#popup2' class='detail2 detail-option' onclick='detail22(event)'>" + item.id + "</a></td>" +
                    "<td><a href='#popup2' class='detail2 detail-option' onclick='detail22(event)'>" + item.inventoryName + "</a></td>" +
                    "<td><a href='#popup2' class='detail2 detail-option' onclick='detail22(event)'>" + item.plantName + "</a></td>" +
                    "<td><a href='#popup2' class='detail2 detail-option' onclick='detail22(event)'><label class='badge badge-info'>" + item.quality + "</label></a></td>" +
                    "<td><a href='#popup2' class='detail2 detail-option' onclick='detail22(event)'>" + text + "</a></td>" +
                    "<td>" +
                    "<button style='border-style: none; background-color:white;'> <i id='" + item.id + "' class='material-icons deleteffff pure2' style='font-size: 28px;color: black;background-color: floralwhite;height: 25px; '>delete</i> </button>" +
                    "</td>" +
                    "</tr>";
                stringArray10.push(rows1);
            }

        }

    });
    
    if (type == 1) {
        console.log(stringArray10);
        var id = '#table1 tbody';
        if (stringArray10.length == 0) {
            $(id).empty()
        }
        else if (stringArray10.length <= 5) {
            $(id).empty()
            for (let i = 0; i < stringArray10.length; i++) {
                $(id).append(stringArray10[i]);
            }
            // If there are less than two elements, take the first one
            totalPages1 = 0;

        } else if (stringArray10.length > 5) {
            if (stringArray10.length % 5 == 0) {
                totalPages1 = Math.round(stringArray10.length / 5);
            } else {
                if (Math.round(stringArray10.length / 5) * 5 > stringArray10.length) {
                    totalPages1 = Math.round(stringArray10.length / 5);

                } else {
                    totalPages1 = Math.round(stringArray10.length / 5);
                    totalPages1++;
                }
            }
            $(id).empty().append(getElementsByPage1(1));
        }
        updatePaginationButtons(1, totalPages1);
    }

    if (type == 2) {
        console.log(stringArray12);
        var id2 = '#table2 tbody';
        if (stringArray12.length == 0) {
            $(id2).empty();
        }
        else if (stringArray12.length <= 5) {
            $(id2).empty();
            for (let i = 0; i < stringArray12.length; i++) {
                $(id2).append(stringArray12[i]);
            }
            // If there are less than two elements, take the first one
            totalPages2 = 0;

        } else if (stringArray12.length > 5) {

            if (stringArray12.length % 5 == 0) {
                totalPages2 = Math.round(stringArray12.length / 5);
            } else {
                if (Math.round(stringArray12.length / 5) * 5 > stringArray12.length) {
                    totalPages2 = Math.round(stringArray12.length / 5);

                } else {
                    totalPages2 = Math.round(stringArray12.length / 5);
                    totalPages2++;
                }

            }
            $(id2).empty().append(getElementsByPage2(1));
        }
        updatePaginationButtons(1, totalPages2);
    }

    if (type == 3) {
        console.log(stringArray18);
        var id3 = '#table3 tbody'; // Corrected the selector to target the tbody of #table3
        if (stringArray18.length == 0) {
            $(id3).empty();
        }
        else if (stringArray18.length <= 5) {
            $(id3).empty();
            for (let i = 0; i < stringArray18.length; i++) {
                $(id3).append(stringArray18[i]);
            }
            // If there are less than two elements, take the first one
            totalPages3 = 0;

        } else if (stringArray18.length > 5) {

            if (stringArray18.length % 5 == 0) {
                totalPages3 = Math.round(stringArray18.length / 5);
            } else {
                if (Math.round(stringArray18.length / 5) * 5 > stringArray18.length) {
                    totalPages3 = Math.round(stringArray18.length / 5);

                } else {
                    totalPages3 = Math.round(stringArray18.length / 5);
                    totalPages3++;
                }
            }
            $(id3).empty().append(getElementsByPage(1));
        }
        updatePaginationButtons(1, totalPages3);
    }
   /* // Check the settings id

    console.log(stringArray10.length);
    console.log(objectArray2);
    console.log(stringArray18.length);
    console.log(totalPages1);
    console.log(totalPages2);
    console.log(totalPages3);*/


}
function checkParameterType() {
    // Get the URL parameters
    const queryString = window.location.search;
    const urlParams = new URLSearchParams(queryString);

    // Get the value of the parameter you're interested in
    const paramValue = urlParams.get('type');

    // Check if the parameter has a value
    if (paramValue !== null && paramValue !== '') {
        // Return the parameter value
        return String(paramValue)[0];

    } else {
        return '0';
    }
}