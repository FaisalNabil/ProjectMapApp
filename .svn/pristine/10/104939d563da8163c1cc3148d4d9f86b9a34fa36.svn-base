/* Custom Js Goes here */
(function ($) {
    "use strict";

    jQuery(document).ready(function ($) {


        
        
        
        /* 
		=================================================================
		01 - Select 2 Custom
		=================================================================	
		*/

            $('.js-example-basic-single').select2();
            $('.multi-select-2').select2();


        $('.timepicker').timepicki();


        /* 
		=================================================================
		01 - Datepicker
		=================================================================	
		*/

        $(function () {
            $(".TeacherBirthDay").datepicker()
            $(".JoinDate").datepicker();
            $(".StudentBirthDay").datepicker();
            $(".payment_report").datepicker();
            $(".payment_report_2").datepicker();
            $(".trans_report").datepicker();
            $(".trans_report_2").datepicker();
            $(".class_bill").datepicker();
            $(".dbblrpt").datepicker();
            $(".dbblrpt2").datepicker();
            $(".carefeesrpt").datepicker();
            $(".carefeesrpt2").datepicker();
            $(".ccfeesrpt").datepicker();
            $(".ccfeesrpt2").datepicker();
            $(".CDate").datepicker({ format: "mm.dd.yyyy" });

        });

        $('#file-upload').change(function () {
            var filepath = this.value;
            var m = filepath.match(/([^\/\\]+)$/);
            var filename = m[1];
            $('#filename').html(filename);

        });


         /*
		=================================================================
		02 - Custom Checkbox
		=================================================================
		*/

        var select_all = document.getElementById("select_all"); //select all checkbox
        var checkboxes = document.getElementsByClassName("checkbox"); //checkbox items

        //select all checkboxes
        select_all.addEventListener("change", function (e) {
            for (i = 0; i < checkboxes.length; i++) {
                checkboxes[i].checked = select_all.checked;
            }
        });


        for (var i = 0; i < checkboxes.length; i++) {
            checkboxes[i].addEventListener('change', function (e) { //".checkbox" change 
                //uncheck "select all", if one of the listed checkbox item is unchecked
                if (this.checked == false) {
                    select_all.checked = false;
                }
                //check "select all" if all checkbox items are checked
                if (document.querySelectorAll('.checkbox:checked').length == checkboxes.length) {
                    select_all.checked = true;
                }
            });
        }


       



        

        
    });



    $('#checkbox_id').on('change', function () {
        check_permanent_add();
    });

    
    function check_permanent_add() {
        
        if (document.getElementById("checkbox_id").checked) {
            var PreVillage = document.getElementById("PreVillage").value;
            var PreHoldingNo = document.getElementById("PreHoldingNo").value;
            var PrePostOffice = document.getElementById("PrePostOffice").value;
            var PreThana = document.getElementById("PreThana").value;
            var PreDistrict = document.getElementById("PreDistrict").value;

            document.getElementById("PerVillage").value = PreVillage;
            document.getElementById("PerHoldingNo").value = PreHoldingNo;
            document.getElementById("PerPostOffice").value = PrePostOffice;
            document.getElementById("PerThana").value = PreThana;
            document.getElementById("PerDistrict").value = PreDistrict;

        } else {
            document.getElementById("PerVillage").value = '';
            document.getElementById("PerHoldingNo").value = '';
            document.getElementById("PerPostOffice").value = '';
            document.getElementById("PerThana").value = '';
            document.getElementById("PerDistrict").value = '';
        }
    }



    

}(jQuery));
