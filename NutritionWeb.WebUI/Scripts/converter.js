var swapUnitText = function (currentUnit) {
    if (currentUnit == "Pounds") {
        return "Kilograms > Pounds";
    }
    else if (currentUnit == "Kilograms") {
        return "Pounds > Kilograms";
    }
    else if (currentUnit == "Inches") {
        return "Centimeters > Inches";
    }
    else if (currentUnit == "Centimeters") {
        return "Inches > Centimeters";
    }
    else if (currentUnit == "Ounces") {
        return "Milliliters > Ounces";
    }
    else if (currentUnit == "Milliliters") {
        return "Ounces > Milliliters";
    }
};

var swapUnit = function (button) {
    var currentUnit = button.val().split(/\s+/)[0];
    button.val(swapUnitText(currentUnit));
};

var poundsToKilos = function (pounds) {
    return (pounds / 2.2).toFixed(2);
};

var kilosToPounds = function (kilos) {
    return (kilos * 2.2).toFixed(2);
};

var convertWeight = function (inWeight, inUnit) {
    if (inUnit == "Pounds") {
        return poundsToKilos(inWeight);
    }
    else {
        return kilosToPounds(inWeight);
    }
};

var inchesToCentimeters = function (inches) {
    return (inches * 2.54).toFixed(2);
};

var centimetersToInches = function (centimeters) {
    return (centimeters / 2.54).toFixed(2);
};

var convertHeight = function (inHeight, inUnit) {
    if (inUnit == "Inches") {
        return inchesToCentimeters(inHeight);
    }
    else {
        return centimetersToInches(inHeight);
    }
};

var ouncesToMilliliters = function (ounces) {
    return (ounces * 29.5735296).toFixed(2);
};

var millilitersToOunces = function (milliliters) {
    return (milliliters / 29.5735296).toFixed(2);
};

var convertVolume = function (inVolume, inUnit) {
    if (inUnit == "Ounces") {
        return ouncesToMilliliters(inVolume);
    }
    else {
        return millilitersToOunces(inVolume);
    }
};



$(document).ready(function () {

    $("#volumeButton").click(function () {
        swapUnit($(this));
        $(".volumeOut").val('');
        $(".volumeIn").val('');
    });

    $("#weightButton").click(function () {
        swapUnit($(this));
        $(".weightOut").val('');
        $(".weightIn").val('');
    });

    $("#heightButton").click(function () {
        swapUnit($(this));
        $(".heightOut").val('');
        $(".heightIn").val('');
    });

    $(".weightIn").keyup(function(e) {
        if (e.which !== 0) {
            $(".weightOut").val(convertWeight($(".weightIn").val(), $("#weightButton").val().split(/\s+/)[0]));
        }
    });

    $(".heightIn").keyup(function (e) {
        if (e.which !== 0) {
            $(".heightOut").val(convertHeight($(".heightIn").val(), $("#heightButton").val().split(/\s+/)[0]));
        }
    });

    $(".volumeIn").keyup(function (e) {
        if (e.which !== 0) {
            $(".volumeOut").val(convertVolume($(".volumeIn").val(), $("#volumeButton").val().split(/\s+/)[0]));
        }
    });
});