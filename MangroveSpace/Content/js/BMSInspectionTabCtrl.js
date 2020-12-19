////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[0]).attr("style", "display:inline-block")//Delamination
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style", "display:inline-block")//Spall
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[2]).attr("style", "display:inline-block")//Exposed Bar
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[3]).attr("style", "display:inline-block")//Efflorescence
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[4]).attr("style", "display:inline-block")//Rust Staining
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "display:inline-block")//Cracking
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[6]).attr("style", "display:inline-block")//Abrasion / Wear
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[7]).attr("style", "display:inline-block")//Distortion
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[8]).attr("style", "display:inline-block")//Settlement
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[9]).attr("style", "display:inline-block")//Collision
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[10]).attr("style", "display:inline-block")//Erosion/Scour
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[11]).attr("style", "display:inline-block")//Corrosion
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[12]).attr("style", "display:inline-block")//Connection Problem
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[13]).attr("style", "display:inline-block")//Mortar Breakdown
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[14]).attr("style", "display:inline-block")//Patched Area
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[15]).attr("style", "display:inline-block")//Masonry Displacement
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[16]).attr("style", "display:inline-block")//Decay / Section Loss
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[17]).attr("style", "display:inline-block")//Check / Shake
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[18]).attr("style", "display:inline-block")//Movement Problem
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[19]).attr("style", "display:inline-block")//Alignment Problem
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[20]).attr("style", "display:inline-block")//Bulging, Splitting or Tearing
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[21]).attr("style", "display:inline-block")//Loss of Bearing Area
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[22]).attr("style", "display:inline-block")//Impact Damage
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[23]).attr("style", "display:inline-block")//Leakage
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[24]).attr("style", "display:inline-block")//Seal Adhesion Defect
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[25]).attr("style", "display:inline-block")//Seal Damage
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[26]).attr("style", "display:inline-block")//Debris Impaction
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[27]).attr("style", "display:inline-block")//Adjacent Deck or Header Defects
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[28]).attr("style", "display:inline-block")//Metal Deterioration or Damage
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[29]).attr("style", "display:inline-block")//Scour
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[30]).attr("style", "display:inline-block")//Aggradation
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[31]).attr("style", "display:inline-block")//Degradation
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[32]).attr("style", "display:inline-block")//Stream Migration
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[33]).attr("style", "display:inline-block")//Undermining
////$($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[34]).attr("style", "display:inline-block")//Debris Accumulation

$(document).ready(function () {
    //var TabStrip = $("#Tabstrip").kendoTabStrip().data("kendoTabStrip");
    var tabStrip = $("#tabstrip").kendoTabStrip().data("kendoTabStrip");

    //  $(TabStrip.items()[2]).hide();       )

    var inspectionFormTypeId = document.getElementById("InspectionFormTypeId").innerHTML.trim();



    var DelaminationPresence = document.getElementById("DelaminationBag").innerHTML.trim();
    //alert("DelaminationPresence " + DelaminationPresence);
    var SpalllPresence = document.getElementById("SpalllBag").innerHTML.trim();
    //alert("SpalllPresence " + SpalllPresence);
    var ExposedBarPresence = document.getElementById("ExposedBarBag").innerHTML.trim();
    //alert("ExposedBarPresence " + ExposedBarPresence);
    var EffloroscencePresence = document.getElementById("EffloroscenceBag").innerHTML.trim();
    //alert("EffloroscencePresence " + EffloroscencePresence);
    var RustStainingPresence = document.getElementById("RustStainingBag").innerHTML.trim();
    //alert("RustStainingPresence " + RustStainingPresence);
    var CrackingPresence = document.getElementById("CrackingBag").innerHTML.trim();
    //alert("CrackingPresence " + CrackingPresence);
    var AbrasionPresence = document.getElementById("AbrasionBag").innerHTML.trim();
    //alert("AbrasionPresence " + AbrasionPresence);
    var DistorsionPresence = document.getElementById("DistorsionBag").innerHTML.trim();
    //alert("DistorsionPresence " + DistorsionPresence);
    var SettlementPresence = document.getElementById("SettlementBag").innerHTML.trim();
    //alert("SettlementPresence " + SettlementPresence);
    var CollImpactDamagePresence = document.getElementById("CollImpactDamageBag").innerHTML.trim();
    //alert("CollImpactDamagePresence " + CollImpactDamagePresence);
    var ErosionScourPresence = document.getElementById("ErosionScourBag").innerHTML.trim();
    //alert("ErosionScourPresence " + ErosionScourPresence);
    var CorrosionPresence = document.getElementById("CorrosionBag").innerHTML.trim();
    //alert("CorrosionPresence " + CorrosionPresence);
    var ConnectionPresence = document.getElementById("ConnectionBag").innerHTML.trim();
    //alert("ConnectionPresence " + ConnectionPresence);
    var MortarBreakdownPresence = document.getElementById("MortarBreakdownBag").innerHTML.trim();
    //alert("MortarBreakdownPresence " + MortarBreakdownPresence);
    var PatchedAreaPresence = document.getElementById("PatchedAreaBag").innerHTML.trim();
    //alert("PatchedAreaPresence " + PatchedAreaPresence);
    var MasonryDisplacementPresence = document.getElementById("MasonryDisplacementBag").innerHTML.trim();
    //alert("MasonryDisplacementPresence " + MasonryDisplacementPresence);
    var DecaySectionLossPresence = document.getElementById("DecaySectionLossBag").innerHTML.trim();
    //alert("DecaySectionLossPresence " + DecaySectionLossPresence);
    var CheckShakePresence = document.getElementById("CheckShakeBag").innerHTML.trim();
    //alert("CheckShakePresence" + CheckShakePresence);
    var MovementProblemPresence = document.getElementById("MovementProblemBag").innerHTML.trim();
    //alert("MovementProblemPresence " + MovementProblemPresence);
    var AlignmentProblemPresence = document.getElementById("AlignmentProblemBag").innerHTML.trim();
    //alert("AlignmentProblemPresence " + AlignmentProblemPresence);
    var BulgingSplittingPresence = document.getElementById("BulgingSplittingBag").innerHTML.trim();
    //alert("BulgingSplittingPresence " + BulgingSplittingPresence);
    var LossBearingPresence = document.getElementById("LossBearingBag").innerHTML.trim();
    //alert("LossBearingPresence " + LossBearingPresence);
    var ImpactDamagePresence = document.getElementById("ImpactDamageBag").innerHTML.trim();
    //alert("ImpactDamagePresence " + ImpactDamagePresence);
    var LeakagePresence = document.getElementById("LeakageBag").innerHTML.trim();
    //alert("LeakagePresence " + LeakagePresence);
    var SealDefectPresence = document.getElementById("SealDefectBag").innerHTML.trim();
    //alert("SealDefectPresence " + SealDefectPresence);
    var SealDamagePresence = document.getElementById("SealDamageBag").innerHTML.trim();
    //alert("SealDamagePresence " + SealDamagePresence);
    var DebrisImpactionPresence = document.getElementById("DebrisImpactionBag").innerHTML.trim();
    //alert("DebrisImpactionPresence " + DebrisImpactionPresence);
    var DeackHeaderDefectsPresence = document.getElementById("DeackHeaderDefectsBag").innerHTML.trim();
    //alert("DeackHeaderDefectsPresence " + DeackHeaderDefectsPresence);
    var MetalDamagePresence = document.getElementById("MetalDamageBag").innerHTML.trim();
    //alert("MetalDamagePresence " + MetalDamagePresence);
    var AggradationPresence = document.getElementById("AggradationBag").innerHTML.trim();
    //alert("AggradationPresence " + AggradationPresence);
    var DegradationPresence = document.getElementById("DegradationBag").innerHTML.trim();
    //alert("DegradationPresence " + DegradationPresence);
    var StreamMigrationPresence = document.getElementById("StreamMigrationBag").innerHTML.trim();
    //alert("StreamMigrationPresence "+StreamMigrationPresence);
    var UnderminingPresence = document.getElementById("UnderminingBag").innerHTML.trim();
    //alert("UnderminingPresence " + UnderminingPresence);
    var DebrisAccumulationPresence = document.getElementById("DebrisAccumulationBag").innerHTML.trim();
    //alert("DebrisAccumulationPresence " + DebrisAccumulationPresence);

    var NotPresentDistress = "";

    if (inspectionFormTypeId == "1")//concrete
    {
        var frontTab = false;

        if (DelaminationPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[0]).attr("style", "font-weight:bold;display:inline-block")//Delamination;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(0);
            }
        }
        else {
            NotPresentDistress += "Delamination:0, ";
        }
        if (SpalllPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style", "font-weight:bold;display:inline-block")//Spall;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(1);
            }
        }
        else {
            NotPresentDistress += "Spall:1, ";
        }
        if (ExposedBarPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[2]).attr("style", "font-weight:bold;display:inline-block")//Exposed Bar;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(2);
            }
        }
        else {
            NotPresentDistress += "Exposed Bar:2, ";
        }
        if (EffloroscencePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[3]).attr("style", "font-weight:bold;display:inline-block")//Efflorescence;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(3);
            }
        }
        else {
            NotPresentDistress += "Efflorescence:3, ";
        }
        if (RustStainingPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[4]).attr("style", "font-weight:bold;display:inline-block")//Rust Staining;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(4);
            }
        }
        else {
            NotPresentDistress += "Rust Staining:4, ";
        }
        if (CrackingPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "font-weight:bold;display:inline-block")//Cracking;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(5);
            }
        }
        else {
            NotPresentDistress += "Cracking:5, ";
        }
        if (AbrasionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[6]).attr("style", "font-weight:bold;display:inline-block")//Abrasion / Wear;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(6);
            }
        }
        else {
            NotPresentDistress += "Abrasion / Wear:6, ";
        }
        if (DistorsionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[7]).attr("style", "font-weight:bold;display:inline-block")//Distortion;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(7);
            }
        }
        else {
            NotPresentDistress += "Distortion:7, ";
        }
        if (SettlementPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[8]).attr("style", "font-weight:bold;display:inline-block")//Settlement;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(8);
            }
        }
        else {
            NotPresentDistress += "Settlement:8, ";
        }
        if (CollImpactDamagePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[9]).attr("style", "font-weight:bold;display:inline-block")//Collision;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(9);
            }
        }
        else {
            NotPresentDistress += "Collision:9, ";
        }
        if (ErosionScourPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[10]).attr("style", "font-weight:bold;display:inline-block")//Erosion/Scour;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(10);
            }
        }
        else {
            NotPresentDistress += "Erosion/Scour:10, ";
        }
        if (PatchedAreaPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[14]).attr("style", "font-weight:bold;display:inline-block")//Patched Area;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(14);
            }
        }
        else {
            NotPresentDistress += "Patched Area:14, ";
        }


    }
    else if (inspectionFormTypeId == "2") {//steel
        var frontTab = false;

        if (CrackingPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "font-weight:bold;display:inline-block")//Cracking;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(5);
            }
        }
        else {
            NotPresentDistress += "Cracking:5, ";
        }
        if (DistorsionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[7]).attr("style", "font-weight:bold;display:inline-block")//Distortion;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(7);
            }
        }
        else {
            NotPresentDistress += "Distortion:7, ";
        }
        if (SettlementPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[8]).attr("style", "font-weight:bold;display:inline-block")//Settlement;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(8);
            }
        }
        else {
            NotPresentDistress += "Settlement:8, ";
        }
        if (CollImpactDamagePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[9]).attr("style", "font-weight:bold;display:inline-block")//Collision;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(9);
            }
        }
        else {
            NotPresentDistress += "Collision:9, ";
        }
        if (ErosionScourPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[10]).attr("style", "font-weight:bold;display:inline-block")//Erosion/Scour;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(10);
            }
        }
        else {
            NotPresentDistress += "Erosion/Scour:10, ";
        }
        if (CorrosionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[11]).attr("style", "font-weight:bold;display:inline-block")//Corrosion;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(11);
            }
        }
        else {
            NotPresentDistress += "Corrosion:11, ";
        }
        if (ConnectionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[12]).attr("style", "font-weight:bold;display:inline-block")//Connection Problem;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(12);
            }
        }
        else {
            NotPresentDistress += "Connection Problem:12, ";
        }

    }
    else if (inspectionFormTypeId == "3") {//timber
        var frontTab = false;
        if (DelaminationPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[0]).attr("style", "font-weight:bold;display:inline-block")//Delamination;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(0);
            }
        }
        else {
            NotPresentDistress += "Delamination:0, ";
        }
        if (CrackingPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "font-weight:bold;display:inline-block")//Cracking;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(5);
            }
        }
        else {
            NotPresentDistress += "Cracking:5, ";
        }
        if (AbrasionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[6]).attr("style", "font-weight:bold;display:inline-block")//Abrasion / Wear;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(6);
            }
        }
        else {
            NotPresentDistress += "Abrasion / Wear:6, ";
        }
        if (DistorsionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[7]).attr("style", "font-weight:bold;display:inline-block")//Distortion;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(7);
            }
        }
        else {
            NotPresentDistress += "Distortion:7, ";
        }
        if (SettlementPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[8]).attr("style", "font-weight:bold;display:inline-block")//Settlement;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(8);
            }
        }
        else {
            NotPresentDistress += "Settlement:8, ";
        }
        if (CollImpactDamagePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[9]).attr("style", "font-weight:bold;display:inline-block")//Collision;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(9);
            }
        }
        else {
            NotPresentDistress += "Collision:9, ";
        }
        if (ErosionScourPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[10]).attr("style", "font-weight:bold;display:inline-block")//Erosion/Scour;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(10);
            }
        }
        else {
            NotPresentDistress += "Erosion/Scour:10, ";
        }
        if (ConnectionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[12]).attr("style", "font-weight:bold;display:inline-block")//Connection Problem;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(12);
            }
        }
        else {
            NotPresentDistress += "Connection Problem:12, ";
        }
        if (DecaySectionLossPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[16]).attr("style", "font-weight:bold;display:inline-block")//Decay / Section Loss;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(16);
            }
        }
        else {
            NotPresentDistress += "Decay / Section Loss:16, ";
        }
        if (CheckShakePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[17]).attr("style", "font-weight:bold;display:inline-block")//Check / Shake;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(17);
            }
        }
        else {
            NotPresentDistress += "Check / Shake:17, ";
        }
    }
    else if (inspectionFormTypeId == "4") {//masonry
        var frontTab = false;
        if (DelaminationPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[0]).attr("style", "font-weight:bold;display:inline-block")//Delamination;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(0);
            }
        }
        else {
            NotPresentDistress += "Delamination:0, ";
        }
        if (SpalllPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[1]).attr("style", "font-weight:bold;display:inline-block")//Spall;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(1);
            }
        }
        else {
            NotPresentDistress += "Spall:1, ";
        }
        if (EffloroscencePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[3]).attr("style", "font-weight:bold;display:inline-block")//Efflorescence;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(3);
            }
        }
        else {
            NotPresentDistress += "Efflorescence:3, ";
        }
        if (RustStainingPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[4]).attr("style", "font-weight:bold;display:inline-block")//Rust Staining;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(4);
            }
        }
        else {
            NotPresentDistress += "Rust Staining:4, ";
        }
        if (DistorsionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[7]).attr("style", "font-weight:bold;display:inline-block")//Distortion;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(7);
            }
        }
        else {
            NotPresentDistress += "Distortion:7, ";
        }
        if (SettlementPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[8]).attr("style", "font-weight:bold;display:inline-block")//Settlement;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(8);
            }
        }
        else {
            NotPresentDistress += "Settlement:8, ";
        }
        if (CollImpactDamagePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[9]).attr("style", "font-weight:bold;display:inline-block")//Collision;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(9);
            }
        }
        else {
            NotPresentDistress += "Collision:9, ";
        }
        if (ErosionScourPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[10]).attr("style", "font-weight:bold;display:inline-block")//Erosion/Scour;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(10);
            }
        }
        else {
            NotPresentDistress += "Erosion/Scour:10, ";
        }
        if (MortarBreakdownPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[13]).attr("style", "font-weight:bold;display:inline-block")//Mortar Breakdown;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(13);
            }
        }
        else {
            NotPresentDistress += "Mortar Breakdown:13, ";
        }
        if (PatchedAreaPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[14]).attr("style", "font-weight:bold;display:inline-block")//Patched Area;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(14);
            }
        }
        else {
            NotPresentDistress += "Patched Area:14, ";
        }
        if (MasonryDisplacementPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[15]).attr("style", "font-weight:bold;display:inline-block")//Masonry Displacement;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(15);
            }
        }
        else {
            NotPresentDistress += "Masonry Displacement:15, ";
        }
    }
    else if (inspectionFormTypeId == "301" || inspectionFormTypeId == "302" || inspectionFormTypeId == "303" || inspectionFormTypeId == "304" || inspectionFormTypeId == "305" || inspectionFormTypeId == "306") {//bearing assembly
        var frontTab = false;
        if (CorrosionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[11]).attr("style", "font-weight:bold;display:inline-block")//Corrosion;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(11);
            }
        }
        else {
            NotPresentDistress += "Corrosion:11, ";
        }
        if (ConnectionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[12]).attr("style", "font-weight:bold;display:inline-block")//Connection Problem;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(12);
            }
        }
        else {
            NotPresentDistress += "Connection Problem:12, ";
        }
        if (MovementProblemPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[18]).attr("style", "font-weight:bold;display:inline-block")//Movement Problem;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(18);
            }
        }
        else {
            NotPresentDistress += "Movement Problem:18, ";
        }
        if (AlignmentProblemPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[19]).attr("style", "font-weight:bold;display:inline-block")//Alignment Problem;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(19);
            }
        }
        else {
            NotPresentDistress += "Alignment Problem:19, ";
        }
        if (BulgingSplittingPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[20]).attr("style", "font-weight:bold;display:inline-block")//Bulging, Splitting or Tearing;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(20);
            }
        }
        else {
            NotPresentDistress += "Bulging, Splitting or Tearing:20, ";
        }
        if (LossBearingPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[21]).attr("style", "font-weight:bold;display:inline-block")//Loss of Bearing Area;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(21);
            }
        }
        else {
            NotPresentDistress += "Loss of Bearing Area:21, ";
        }
    }
    else if (inspectionFormTypeId == "601" || inspectionFormTypeId == "602" || inspectionFormTypeId == "603" || inspectionFormTypeId == "604" || inspectionFormTypeId == "605" || inspectionFormTypeId == "606" || inspectionFormTypeId == "607" || inspectionFormTypeId == "608" || inspectionFormTypeId == "609" || inspectionFormTypeId == "610") {//joints
        var frontTab = false;
        if (CrackingPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[5]).attr("style", "font-weight:bold;display:inline-block")//Cracking;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(5);
            }
        }
        else {
            NotPresentDistress += "Cracking:5, ";
        }
        if (ImpactDamagePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[22]).attr("style", "font-weight:bold;display:inline-block")//Impact Damage;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(22);
            }
        }
        else {
            NotPresentDistress += "Impact Damage:22, ";
        }
        if (LeakagePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[23]).attr("style", "font-weight:bold;display:inline-block")//Leakage;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(23);
            }
        }
        else {
            NotPresentDistress += "Leakage:23, ";
        }
        if (SealDefectPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[24]).attr("style", "font-weight:bold;display:inline-block")//Seal Adhesion Defect;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(24);
            }
        }
        else {
            NotPresentDistress += "Seal Adhesion Defect:24, ";
        }
        if (SealDamagePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[25]).attr("style", "font-weight:bold;display:inline-block")//Seal Damage;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(25);
            }
        }
        else {
            NotPresentDistress += "Seal Damage:25, ";
        }
        if (DebrisImpactionPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[26]).attr("style", "font-weight:bold;display:inline-block")//Debris Impaction;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(26);
            }
        }
        else {
            NotPresentDistress += "Debris Impaction:26, ";
        }
        if (DeackHeaderDefectsPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[27]).attr("style", "font-weight:bold;display:inline-block")//Adjacent Deck or Header Defects;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(27);
            }
        }
        else {
            NotPresentDistress += "Adjacent Deck or Header Defects:27, ";
        }
        if (MetalDamagePresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[28]).attr("style", "font-weight:bold;display:inline-block")//Metal Deterioration or Damage;
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(28);
            }
        }
        else {
            NotPresentDistress += "Metal Deterioration or Damage:28, ";
        }
    }
    else if (inspectionFormTypeId == "800") {//channel navigation
        var frontTab = false;
        if (AggradationPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[30]).attr("style", "font-weight:bold;display:inline-block")//Aggradation
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(30);
            }
        }
        else {
            NotPresentDistress += "Aggradation:30, ";
        }
        if (DegradationPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[31]).attr("style", "font-weight:bold;display:inline-block")//Degradation
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(31);
            }
        }
        else {
            NotPresentDistress += "Degradation:31, ";
        }
        if (StreamMigrationPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[32]).attr("style", "font-weight:bold;display:inline-block")//Stream Migration
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(32);
            }
        }
        else {
            NotPresentDistress += "Stream Migration:32, ";
        }
        if (UnderminingPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[33]).attr("style", "font-weight:bold;display:inline-block")//Undermining
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(33);
            }
        }
        else {
            NotPresentDistress += "Undermining:33, ";
        }
        if (DebrisAccumulationPresence == "1") {
            $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[34]).attr("style", "font-weight:bold;display:inline-block")//Debris Accumulation
            if (!frontTab) {
                frontTab = true;
                $("#tabstrip").data("kendoTabStrip").select(34);
            }
        }
        else {
            NotPresentDistress += "Debris Accumulation:34, ";
        }

    }
    else if (inspectionFormTypeId == "705" || inspectionFormTypeId == "502" || inspectionFormTypeId == "504" || inspectionFormTypeId == "702") {
        $($("#tabstrip").kendoTabStrip().data("kendoTabStrip").items()[0]).attr("style", "font-weight:bold;display:inline-block")//Delamination;
    }

    //alert(NotPresentDistress);

    $.ajax({  
        type: 'GET',  
        url: 'BMSInspectionStructure/SetNotPresentDistresses',
        data: { NotPresents: NotPresentDistress },
        datatype: "html",
        traditional: true,
        success: function(data) {  
            //alert(data.msg);  
        },  
        error: function(data) {  
            console.log(data);
        }  
    }); 


});