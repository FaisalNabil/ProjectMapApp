//this.hideColumn("PierCapMaterial");

//this.hideColumn("Abtmaterial");
//this.hideColumn("AbtNumber");
//this.hideColumn("AbtHeight");
//this.hideColumn("AbtWidth");
//this.hideColumn("AbtThickness");
//this.hideColumn("AbtFoundationType");
//this.hideColumn("AbtWeepHolePresent");

//this.hideColumn("WingWallMaterial");
//this.hideColumn("WingWallType");
//this.hideColumn("WingWallWeepHolePresent");

//this.hideColumn("PierCapMaterial");
//this.hideColumn("PierCapXSectionGEO");
//this.hideColumn("PierCapNumber");
//this.hideColumn("PierCapThickness");

//this.hideColumn("PierMaterial");
//this.hideColumn("PierXSectionGEO");
//this.hideColumn("PierXSectionLength");
//this.hideColumn("PierXSectionWidth");
//this.hideColumn("PierDiameter");
//this.hideColumn("PierNumber");

//this.hideColumn("PileCapMaterial");
//this.hideColumn("PileCapNumber");
//this.hideColumn("PileCapPosition");

//this.hideColumn("PileMaterial");
//this.hideColumn("PileNumber");
//this.hideColumn("PileType");
//this.hideColumn("PileDepth");
//this.hideColumn("PileDiameter");

//this.hideColumn("BottomSlabMaterial");
//this.hideColumn("BottomSlabThickness");

//this.hideColumn("MiddleWallPresent");
//this.hideColumn("MiddleWallMaterial");
//this.hideColumn("MiddleWallNumber");
//this.hideColumn("MiddleWallThickness");

//this.hideColumn("HeadWallPresent");
//this.hideColumn("HeadWallHeight");
//this.hideColumn("HeadWallWidth");
//this.hideColumn("HeadWallMaterial");

//this.hideColumn("PipeMaterial");
//this.hideColumn("PipeNumber");
//this.hideColumn("PipeDiameter");

//this.hideColumn("KeyStoneMaterial");
//this.hideColumn("KeyStoneNumber");
//this.hideColumn("KeyStoneThickness");

//this.hideColumn("ArchringMaterial");
//this.hideColumn("ArchringNumber");
//this.hideColumn("ArchringThickness");

function onRowBound(e) {
        if (localStorage.getItem("isView") == "View Data") {
            $(".k-grid-edit").remove();
        }
        var isPermitted = GetInventoryPermission("UpdateStructureSpecific");
        if (isPermitted === true) {
            $(".k-grid-edit").find("span").addClass("k-i-pencil");
        } else {
            $(".k-grid-edit").remove();
        }

        
        var bridgeTyepId = document.getElementById("bridgeTyepId").innerHTML;
        console.log(bridgeTyepId);

        var SubStructure = $("#SubStructure").data("kendoGrid");
        var SuperStructure = $("#SuperStructure").data("kendoGrid");
        var Deck = $("#Deck").data("kendoGrid");
        var Approach = $("#Approach").data("kendoGrid");
        var ChannelNavigation = $("#ChannelNavigation").data("kendoGrid");

        //SubStructure.showColumn(0);//Abutment
        //SubStructure.showColumn(1);//Wing Wall
        //SubStructure.showColumn(2);//Pier Cap
        //SubStructure.showColumn(3);//Pier
        //SubStructure.showColumn(4);//Pile Cap
        //SubStructure.showColumn(5);//Pile
        //SubStructure.showColumn(6);//Bottom Slab
        //SubStructure.showColumn(7);//Middle Wall
        //SubStructure.showColumn(8);//Head Wall
        //SubStructure.showColumn(9);//Pipe
        //SubStructure.showColumn(10);//Keystone
        //SubStructure.showColumn(11);//Arch Ring

        //SuperStructure.showColumn(0);//Stringer
        //SuperStructure.showColumn(1);//Bracing
        //SuperStructure.showColumn(2);//Connection
        //SuperStructure.showColumn(3);//Transom
        //SuperStructure.showColumn(4);//Panel
        //SuperStructure.showColumn(5);//Cross Girder
        //SuperStructure.showColumn(6);//Girder
        //SuperStructure.showColumn(7);//Diaphragm
        //SuperStructure.showColumn(8);//Long Beam
        //SuperStructure.showColumn(9);//Trans Beam
        //SuperStructure.showColumn(10);//Vertical Post and Diagonal
        //SuperStructure.showColumn(11);//Chords
        //SuperStructure.showColumn(12);//Strut

        //Deck.showColumn(0);//Deck Slab
        //Deck.showColumn(1);//Wearing Surface
        //Deck.showColumn(2);//Drainage Device
        //Deck.showColumn(3);//Railing
        //Deck.showColumn(4);//Parapet
        //Deck.showColumn(5);//Median
        //Deck.showColumn(6);//Top Slab
        //Deck.showColumn(7);//Side Walk

        //Approach.showColumn(0);//Guardrail
        //Approach.showColumn(1);//Embankment Slope
        //Approach.showColumn(2);//Approach Slab
        //Approach.showColumn(3);//Approach Parapet
        //Approach.showColumn(4);//Approach Wearing Surface

        //ChannelNavigation.showColumn(0);//Channel Alignment
        //ChannelNavigation.showColumn(1);//Abutment Protection
        //ChannelNavigation.showColumn(2);//Pier Protection
        //ChannelNavigation.showColumn(3);//Navigational Vertical Clearance
        //ChannelNavigation.showColumn(4);//Navigational Lateral Clearance
        //ChannelNavigation.showColumn(5);//Apron
        //ChannelNavigation.showColumn(6);//Culvert Opening

        if (bridgeTyepId == 101)//BOX CULVERT
        {
            try{
                SubStructure.showColumn(0);//Abutment
                SubStructure.showColumn(1);//Wing Wall
                SubStructure.showColumn(6);//Bottom Slab
                SubStructure.showColumn(7);//Middle Wall
            } catch(err){

            }

            try{
                Deck.showColumn(1);//Wearing Surface
                Deck.showColumn(2);//Drainage Device
                Deck.showColumn(4);//Parapet
                Deck.showColumn(5);//Median
                Deck.showColumn(6);//Top Slab
            } catch (err) {

            }

            try {
                Approach.showColumn(0);//Guardrail
                Approach.showColumn(1);//Embankment Slope
                Approach.showColumn(2);//Approach Slab
            } catch (err) {

            }

            try {
                ChannelNavigation.showColumn(1);//Abutment Protection
                ChannelNavigation.showColumn(5);//Apron
                ChannelNavigation.showColumn(6);//Culvert Opening
            } catch (e) {

            }
        }
       else if (bridgeTyepId == 102)//PIPE CULVERT
        {
           try {
               SubStructure.showColumn(1);//Wing Wall
               SubStructure.showColumn(8);//Head Wall
               SubStructure.showColumn(9);//Pipe
           } catch (e) {

           }

           try {
               Approach.showColumn(1);//Embankment Slope
           } catch (e) {

           }

        }
       else if (bridgeTyepId == 103)//GIRDER BRIDGE
       {
           
           try {
               SubStructure.showColumn(0);//Abutment
               SubStructure.showColumn(1);//Wing Wall
               SubStructure.showColumn(2);//Pier Cap
               SubStructure.showColumn(3);//Pier
               SubStructure.showColumn(4);//Pile Cap
               SubStructure.showColumn(5);//Pile
           } catch (e) {

           }

           try {
               SuperStructure.showColumn(5);//Cross Girder
               SuperStructure.showColumn(6);//Girder
               SuperStructure.showColumn(7);//Diaphragm
           } catch (e) {

           }

           try {
               Deck.showColumn(0);//Deck Slab
               Deck.showColumn(1);//Wearing Surface
               Deck.showColumn(2);//Drainage Device
               Deck.showColumn(3);//Railing
               Deck.showColumn(5);//Median
               Deck.showColumn(7);//Side Walk
           } catch (e) {

           }

           try {
               Approach.showColumn(0);//Guardrail
               Approach.showColumn(1);//Embankment Slope
               Approach.showColumn(2);//Approach Slab
               Approach.showColumn(3);//Approach Parapet
               Approach.showColumn(4);//Approach Wearing Surface
           } catch (e) {

           }

           try {
               ChannelNavigation.showColumn(0);//Channel Alignment
               ChannelNavigation.showColumn(1);//Abutment Protection
               ChannelNavigation.showColumn(3);//Navigational Vertical Clearance
               ChannelNavigation.showColumn(4);//Navigational Lateral Clearance
           } catch (e) {

           }
        }
       else if (bridgeTyepId == 104)//ARC MASONRY
        {
           try {
               SubStructure.showColumn(0);//Abutment
               SubStructure.showColumn(1);//Wing Wall
               SubStructure.showColumn(7);//Middle Wall
               SubStructure.showColumn(10);//Keystone
               SubStructure.showColumn(11);//Arch Ring
           } catch (e) {

           }

           try {
               Deck.showColumn(1);//Wearing Surface
               Deck.showColumn(2);//Drainage Device
               Deck.showColumn(4);//Parapet
               Deck.showColumn(5);//Median
               Deck.showColumn(7);//Side Walk
           } catch (e) {

           }

           try {
               Approach.showColumn(0);//Guardrail
               Approach.showColumn(1);//Embankment Slope
               Approach.showColumn(2);//Approach Slab
           } catch (e) {

           }

           try {
               ChannelNavigation.showColumn(0);//Channel Alignment
               ChannelNavigation.showColumn(1);//Abutment Protection
           } catch (e) {

           }
        }
       else if (bridgeTyepId == 105)//WOODEN BRIDGE
        {
           try {
               SubStructure.showColumn(0);//Abutment
               SubStructure.showColumn(1);//Wing Wall
               SubStructure.showColumn(7);//Middle Wall
           } catch (e) {

           }

           try {
               SuperStructure.showColumn(2);//Connection
               SuperStructure.showColumn(7);//Diaphragm
               SuperStructure.showColumn(8);//Long Beam
               SuperStructure.showColumn(9);//Trans Beam
           } catch (e) {

           }
          
           try {
               Deck.showColumn(0);//Deck Slab
               Deck.showColumn(1);//Wearing Surface
               Deck.showColumn(2);//Drainage Device
               Deck.showColumn(3);//Railing
           } catch (e) {

           }

           try {
               Approach.showColumn(0);//Guardrail
               Approach.showColumn(1);//Embankment Slope
               Approach.showColumn(2);//Approach Slab
           } catch (e) {

           }

           try {
               ChannelNavigation.showColumn(1);//Abutment Protection
               ChannelNavigation.showColumn(2);//Pier Protection
               ChannelNavigation.showColumn(3);//Navigational Vertical Clearance
               ChannelNavigation.showColumn(4);//Navigational Lateral Clearance
           } catch (e) {

           }
        }
       else if (bridgeTyepId == 106)//BAILEY BRIDGE
        {
           try {
               SubStructure.showColumn(0);//Abutment
               SubStructure.showColumn(1);//Wing Wall
               SubStructure.showColumn(2);//Pier Cap
               SubStructure.showColumn(3);//Pier
               SubStructure.showColumn(4);//Pile Cap
               SubStructure.showColumn(5);//Pile
           } catch (e) {

           }

           try {
               SuperStructure.showColumn(0);//Stringer
               SuperStructure.showColumn(1);//Bracing
               SuperStructure.showColumn(2);//Connection
               SuperStructure.showColumn(3);//Transom
               SuperStructure.showColumn(4);//Panel
           } catch (e) {

           }

           try {
               Deck.showColumn(0);//Deck Slab
               Deck.showColumn(1);//Wearing Surface
               Deck.showColumn(2);//Drainage Device
               Deck.showColumn(3);//Railing
           } catch (e) {

           }

           try {
               Approach.showColumn(0);//Guardrail
               Approach.showColumn(1);//Embankment Slope
               Approach.showColumn(2);//Approach Slab
               Approach.showColumn(3);//Approach Parapet
               Approach.showColumn(4);//Approach Wearing Surface
           } catch (e) {

           }

           try {
               ChannelNavigation.showColumn(0);//Channel Alignment
               ChannelNavigation.showColumn(1);//Abutment Protection
               ChannelNavigation.showColumn(2);//Pier Protection
               ChannelNavigation.showColumn(3);//Navigational Vertical Clearance
               ChannelNavigation.showColumn(4);//Navigational Lateral Clearance
           } catch (e) {

           }
        }
       else if (bridgeTyepId == 107)//TRUSS
        {
           try {
               SubStructure.showColumn(0);//Abutment
               SubStructure.showColumn(1);//Wing Wall
               SubStructure.showColumn(2);//Pier Cap
               SubStructure.showColumn(3);//Pier
               SubStructure.showColumn(4);//Pile Cap
               SubStructure.showColumn(5);//Pile
           } catch (e) {

           }

           try {
               SuperStructure.showColumn(0);//Stringer
               SuperStructure.showColumn(1);//Bracing
               SuperStructure.showColumn(2);//Connection
               SuperStructure.showColumn(5);//Cross Girder
               SuperStructure.showColumn(10);//Vertical Post and Diagonal
               SuperStructure.showColumn(11);//Chords
               SuperStructure.showColumn(12);//Strut
           } catch (e) {

           }

           try {
               Deck.showColumn(0);//Deck Slab
               Deck.showColumn(1);//Wearing Surface
               Deck.showColumn(2);//Drainage Device
               Deck.showColumn(3);//Railing
               Deck.showColumn(5);//Median
               Deck.showColumn(7);//Side Walk
           } catch (e) {

           }

           try {
               Approach.showColumn(0);//Guardrail
               Approach.showColumn(1);//Embankment Slope
               Approach.showColumn(2);//Approach Slab
               Approach.showColumn(3);//Approach Parapet
               Approach.showColumn(4);//Approach Wearing Surface
           } catch (e) {

           }

           try {
               ChannelNavigation.showColumn(0);//Channel Alignment
               ChannelNavigation.showColumn(1);//Abutment Protection
               ChannelNavigation.showColumn(2);//Pier Protection
               ChannelNavigation.showColumn(3);//Navigational Vertical Clearance
               ChannelNavigation.showColumn(4);//Navigational Lateral Clearance
           } catch (e) {

           }
        }
       else if (bridgeTyepId == 108)//FLYOVER
       {
           try {
               SubStructure.showColumn(0);//Abutment
               SubStructure.showColumn(1);//Wing Wall
               SubStructure.showColumn(2);//Pier Cap
               SubStructure.showColumn(3);//Pier
               SubStructure.showColumn(4);//Pile Cap
               SubStructure.showColumn(5);//Pile
           } catch (e) {

           }

           try {
               SuperStructure.showColumn(0);//Stringer
               SuperStructure.showColumn(1);//Bracing
               SuperStructure.showColumn(2);//Connection
               SuperStructure.showColumn(5);//Cross Girder
               SuperStructure.showColumn(6);//Girder
               SuperStructure.showColumn(7);//Diaphragm
           } catch (e) {

           }

           try {
               Deck.showColumn(0);//Deck Slab
               Deck.showColumn(1);//Wearing Surface
               Deck.showColumn(3);//Railing
               Deck.showColumn(5);//Median
               Deck.showColumn(7);//Side Walk
           } catch (e) {

           }

           try {
               Approach.showColumn(0);//Guardrail
               Approach.showColumn(1);//Embankment Slope
               Approach.showColumn(2);//Approach Slab
               Approach.showColumn(3);//Approach Parapet
               Approach.showColumn(4);//Approach Wearing Surface
           } catch (e) {

           }

           try {
               ChannelNavigation.showColumn(3);//Navigational Vertical Clearance
               ChannelNavigation.showColumn(4);//Navigational Lateral Clearance
           } catch (e) {

           }
       }
       else if (bridgeTyepId == 109)//SLAB CULVERT
       {
           try {
               SubStructure.showColumn(0);//Abutment
               SubStructure.showColumn(1);//Wing Wall
           } catch (e) {

           }

           try {
               Deck.showColumn(1);//Wearing Surface
               Deck.showColumn(2);//Drainage Device
               Deck.showColumn(4);//Parapet
               Deck.showColumn(5);//Median
               Deck.showColumn(6);//Top Slab
           } catch (e) {

           }

           try {
               Approach.showColumn(0);//Guardrail
               Approach.showColumn(1);//Embankment Slope
               Approach.showColumn(2);//Approach Slab
           } catch (e) {

           }

           try {
               ChannelNavigation.showColumn(1);//Abutment Protection
               ChannelNavigation.showColumn(5);//Apron
               ChannelNavigation.showColumn(6);//Culvert Opening
           } catch (e) {

           }
       }
       else if (bridgeTyepId == 110)//U-Drain
       {
           try {
               SubStructure.showColumn(0);//Abutment
           } catch (e) {

           }

           try {
               Deck.showColumn(1);//Wearing Surface
               Deck.showColumn(2);//Drainage Device
               Deck.showColumn(4);//Parapet
               Deck.showColumn(5);//Median
               Deck.showColumn(6);//Top Slab
           } catch (e) {

           }

           try {
               Approach.showColumn(0);//Guardrail
               Approach.showColumn(1);//Embankment Slope
               Approach.showColumn(2);//Approach Slab
           } catch (e) {

           }

           try {
               ChannelNavigation.showColumn(1);//Abutment Protection
               ChannelNavigation.showColumn(5);//Apron
               ChannelNavigation.showColumn(6);//Culvert Opening
           } catch (e) {

           }
       }
       else if (bridgeTyepId == 111)//Light Traffic Bridge
       {
           try {
               SubStructure.showColumn(0);//Abutment
               SubStructure.showColumn(1);//Wing Wall
               SubStructure.showColumn(2);//Pier Cap
               SubStructure.showColumn(3);//Pier
               SubStructure.showColumn(4);//Pile Cap
               SubStructure.showColumn(5);//Pile
           } catch (e) {

           }

           try {
               SuperStructure.showColumn(0);//Stringer
               SuperStructure.showColumn(1);//Bracing
               SuperStructure.showColumn(2);//Connection
               SuperStructure.showColumn(5);//Cross Girder
               SuperStructure.showColumn(6);//Girder
               SuperStructure.showColumn(7);//Diaphragm
           } catch (e) {

           }

           try {
               Deck.showColumn(0);//Deck Slab
               Deck.showColumn(1);//Wearing Surface
               Deck.showColumn(2);//Drainage Device
               Deck.showColumn(3);//Railing
               Deck.showColumn(5);//Median
               Deck.showColumn(7);//Side Walk
           } catch (e) {

           }

           try {
               Approach.showColumn(0);//Guardrail
               Approach.showColumn(1);//Embankment Slope
               Approach.showColumn(2);//Approach Slab
               Approach.showColumn(3);//Approach Parapet
               Approach.showColumn(4);//Approach Wearing Surface
           } catch (e) {

           }

           try {
               ChannelNavigation.showColumn(0);//Channel Alignment
               ChannelNavigation.showColumn(1);//Abutment Protection
               ChannelNavigation.showColumn(2);//Pier Protection
               ChannelNavigation.showColumn(3);//Navigational Vertical Clearance
               ChannelNavigation.showColumn(4);//Navigational Lateral Clearance
           } catch (e) {

           }
       }
       else if (bridgeTyepId == 112)//Existing Gap
       {
           //nothing
       }
       else if (bridgeTyepId == 113)//Other Structures
       {
           //nothing
       }
        else
        {

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
                    model.hideColumn("MiddleWallMaterial");
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

                    model.showColumn("MiddleWallMaterial");
                    model.showColumn("MiddleWallThickness");
                    model.showColumn("MiddleWallNumber");

                    //model.fields["MiddleWallMateril"].show();
                    //model.fields["MiddleWallThickness"].show();// = false;
                    //model.fields["MiddleWallNumber"].show();// = false;
                }
            }
        }
    }