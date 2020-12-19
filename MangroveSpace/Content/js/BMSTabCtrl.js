$(document).ready(function () {
    //var TabStrip = $("#Tabstrip").kendoTabStrip().data("kendoTabStrip");
    var tabStrip = $("#tabstrip").kendoTabStrip().data("kendoTabStrip");

    //  $(TabStrip.items()[2]).hide();       )
    //$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[0]).attr("style", "display:none") //Sub-Structure
    //$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style", "display:none") //Bearing Assembly
    //$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[2]).attr("style", "display:none") //Super-Structure
    //$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[3]).attr("style", "display:none") //Deck
    //$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[4]).attr("style", "display:none") //Joint
    //$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "display:none") //Viaduct
    //$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[6]).attr("style", "display:none") //Approach
    //$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[7]).attr("style", "display:none") //Channel & Navigation
    //$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[8]).attr("style", "display:none") //Safety Feature
  

    var bridgeTyepId = document.getElementById("bridgeTyepId").innerHTML;
    if (bridgeTyepId == 101) 
    {
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[2]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[4]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "display:none")

    }
    else if (bridgeTyepId == 102) 
    {
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style","display:none") 
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[2]).attr("style","display:none") 
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[3]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[4]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[7]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[8]).attr("style", "display:none")

    }
    else if (bridgeTyepId == 103) 
    {
        //nothing to hide
    }
    else if (bridgeTyepId == 104) 
    {
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[2]).attr("style", "display:none")
    }
    else if (bridgeTyepId == 105) 
    {
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style","display:none") 
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[4]).attr("style","display:none") 
    }
    else if (bridgeTyepId == 106) {
        //nothing to hide
    }
    else if (bridgeTyepId == 107) {
        //nothing to hide
    }
    else if (bridgeTyepId == 108) {
        //nothing to hide
    }
    else if (bridgeTyepId == 109) {
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style","display:none") 
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[2]).attr("style","display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[4]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[7]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[8]).attr("style", "display:none")
    }
    else if (bridgeTyepId == 110) {
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style","display:none") 
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[2]).attr("style","display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[4]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[7]).attr("style", "display:none")
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[8]).attr("style", "display:none")
    }
    else if (bridgeTyepId == 111) {
        //nothing to hide
    }
    
});