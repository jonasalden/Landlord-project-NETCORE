﻿$(function () {
    $("#rental-rent-slider").slider({
        range: true,
        values: [parseInt($('#MinRent').val()), parseInt($('#MaxRent').val())],
        min: parseInt($('#MinRent').val()),
        max: parseInt($('#MaxRent').val()),
        slide: function (event, ui) {
            $("#rental-rent-amount").text(ui.values[0] + " kr - " + ui.values[1] + " kr");
        }
    });
    $("#rental-rent-amount").text($("#rental-rent-slider").slider("values", 0) + " kr - " + $("#rental-rent-slider").slider("values", 1) + " kr");
});
$(document).ready(function () {
    $("#rental-rent-slider").on("slidechange", function (event, ui) {
        //LoadingScreen(true);
        var rooms = parseInt($("#rental-room-amount").val());
        var minPrice = $("#rental-rent-slider").slider("values", 0);
        var maxPrice = $("#rental-rent-slider").slider("values", 1);
        var area = $('#SelectedArea').val();
        var sortby = $('#SortBy').val();
        Filter(rooms, minPrice, maxPrice, area, sortby);
    });
});
$(function () {
    var select = $("#rental-room-amount");
    var slider = $("<div id='rental-room-slider'></div>").insertAfter(select).slider({
        min: 1,
        max: parseInt($('#MaxRooms').val()),
    range: "min",
        value: select[0].selectedIndex + 1,
            slide: function (event, ui) {
                select[0].selectedIndex = ui.value - 1;
            }
        });
$("#rental-room-amount").on("change", function () {
    //LoadingScreen(true);

    slider.slider("value", this.selectedIndex + 1);

    var rooms = parseInt(this.selectedIndex + 1);
    var minPrice = $("#rental-rent-slider").slider("values", 0);
    var maxPrice = $("#rental-rent-slider").slider("values", 1);
    var area = $('#SelectedArea').val();
    var sortby = $('#SortBy').val();

    Filter(rooms, minPrice, maxPrice, area, sortby);
});

$("#rental-room-slider").on("slidestop", function (event, ui) {
    //LoadingScreen(true);
    var rooms = parseInt(ui.value);

    $.ajax({
        url: "Home/FilterPrice",
        type: "GET",
        data: { rooms, minPrice: parseInt($("#rental-rent-slider").slider("values", 0)), maxPrice: parseInt($("#rental-rent-slider").slider("values", 1)) },
        success: function (data) {
            $('#rental-list-thumb-container').empty();
            $('#rental-list-thumb-container').html(data);

            var numItems = $('#rental-list-thumb-container .residence-thumb').length;
            $('#rental-list-total').text("(" + parseInt(numItems) + ")");
            //LoadingScreen(false);
        }
    });
});
    });
function LoadThumbs() {
    $('.residence-thumb').each(function (index) {
        console.log(index + ": " + $(this).text());
        $(this).delay(100).animate({ opacity: 1 }, 700);
    });
};
$('#SortBy').on('change', function () {
    console.log($('#SortBy').val());
    var rooms = parseInt($("#rental-room-amount").val());
    var minPrice = $("#rental-rent-slider").slider("values", 0);
    var maxPrice = $("#rental-rent-slider").slider("values", 1);
    var area = $('#SelectedArea').val();
    var sortby = $('#SortBy').val();

    Filter(rooms, minPrice, maxPrice, area, sortby);
});
$('#SelectedArea').on('change', function () {
    var rooms = parseInt($("#rental-room-amount").val());
    var minPrice = $("#rental-rent-slider").slider("values", 0);
    var maxPrice = $("#rental-rent-slider").slider("values", 1);
    var area = $(this).val();
    var sortby = $('#SortBy').val();

    Filter(rooms, minPrice, maxPrice, area, sortby);
});

function Filter(rooms, minPrice, maxPrice, area, sortby) {
    rooms = parseInt(rooms);
    minPrice = parseInt(minPrice);
    maxPrice = parseInt(maxPrice);
    area = area;
    sortby = parseInt(sortby);

    console.log("rooms: " + rooms);
    console.log("minPrice: " + minPrice);
    console.log("maxPrice: " + maxPrice);
    console.log("area: " + area);
    console.log("sortby: " + sortby);

    $.ajax({
        url: "Home/FilterPrice",
        type: "GET",
        data: { rooms, minPrice, maxPrice, area, sortby },
        success: function (data) {
            $('#rental-list-thumb-container').empty();
            $('#rental-list-thumb-container').html(data);

            var numItems = $('#rental-list-thumb-container .residence-thumb').length;
            $('#rental-list-total').text("(" + parseInt(numItems) + ")");
            //LoadingScreen(false);
        }
    });
}
