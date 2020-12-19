function onRowBound(e) {
    if (localStorage.getItem("isView") == "View Data") {
        $(".k-upload-button").remove();
        $(".k-grid-edit").remove();
    }
    var isPermitted = GetInspectionPermission("UpdateInspectionDetails");
    if (isPermitted === true) {
        $(".k-grid-edit").find("span").addClass("k-i-pencil");
    } else {
        $(".k-upload-button").remove();
        $(".k-grid-edit").remove();
    }

    var inspectionFormTypeId = document.getElementById("InspectionFormTypeId").innerHTML.trim();
    var formName = document.getElementById("FormName").innerHTML.trim();

    if (inspectionFormTypeId == "1")//Concrete
    {
        if (formName.includes("BridgeType"))//BridgeType
        {
            this.hideColumn("BearingType");
            this.hideColumn("JointType");
            this.hideColumn("JointLocation");
        }
        //if (formName.includes("Spall"))//Spall
        //{
        //    this.hideColumn("Level");
        //}
        //if (formName.includes("Cracking")) {
        //    this.hideColumn("Level");
        //}
        //if (formName.includes("Abrasion")) {
        //    this.hideColumn("Level");

        //}
        //if (formName.includes("Settlement")) {
        //    this.hideColumn("Level");
        //}

    }
    else if (inspectionFormTypeId == "102")//Steel
    {
        if (formName.includes("BridgeType"))//BridgeType
        {
            this.hideColumn("BearingType");
            this.hideColumn("JointType");
            this.hideColumn("JointLocation");
        }
        if (formName.includes("Cracking")) {
            this.hideColumn("Number");
            this.hideColumn("Width");
        }


    }
    else if (inspectionFormTypeId == "4")//MANSORY
    {
        if (formName.includes("BridgeType")) {
            this.hideColumn("BearingType");
            this.hideColumn("JointType");
            this.hideColumn("JointLocation");
        }

        //if (formName.includes("PatchedArea")) {
        //    this.hideColumn("Level");

        //}
    }
    else if (inspectionFormTypeId == "104")//Timber
    {
        if (formName.includes("BridgeType")) {
            this.hideColumn("BearingType");
            this.hideColumn("JointType");
            this.hideColumn("JointLocation");
        }
        if (formName.includes("Cracking")) {
            this.hideColumn("Number");
            this.hideColumn("Width");
        }
        if (formName.includes("Delamination")) {
            this.hideColumn("Depth");
            this.hideColumn("Radius");
        }
        if (formName.includes("Abrasion")) {
            this.hideColumn("Exposure");
        }

    }
    else if (inspectionFormTypeId == "105")//Bearing Assembly
    {
        if (formName.includes("BridgeType")) {
            this.hideColumn("BearingType");
            this.hideColumn("JointType");
            this.hideColumn("JointLocation");
        }

    }
    else if (inspectionFormTypeId == "106")//Joints
    {
        if (formName.includes("Cracking")) {
            this.hideColumn("Number");
            this.hideColumn("Width");
        }

    }
    else if (inspectionFormTypeId == "107")//TRUSS
    {
        if (formName.includes("BridgeType"))//BridgeType
        {
            this.hideColumn("BearingType");
            this.hideColumn("JointType");
            this.hideColumn("JointLocation");
        }


    }

    else {

        //alert(bridgeTyepId);
    }


}
function middlewall_change(e) {
    var widget = e.sender;
    var value = widget.value();

    var len = $("#SubStructure").find("tbody tr").length;

    if (value == "1") {
        for (var i = 0; i <= len ; i++) {
            var model = $("#SubStructure").data("kendoGrid").dataSource.at(i);
            if (model) {//field names
                model.hideColumn("MiddleWallMateril");
                model.hideColumn("MiddleWallThickness");
                model.hideColumn("MiddleWallNumber");
            }

        }

        //this.hideColumn("MiddleWallMateril");
        //this.hideColumn("MiddleWallThickness");
        //this.hideColumn("MiddleWallNumber");
    }
    else {
        for (var i = 0; i <= len ; i++) {
            var model = $("#SubStructure").data("kendoGrid").dataSource.at(i);
            if (model) {//field names

                model.showColumn("MiddleWallMateril");
                model.showColumn("MiddleWallThickness");
                model.showColumn("MiddleWallNumber");

                //model.fields["MiddleWallMateril"].show();
                //model.fields["MiddleWallThickness"].show();// = false;
                //model.fields["MiddleWallNumber"].show();// = false;
            }
        }
    }
}