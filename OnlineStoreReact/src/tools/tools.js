import $ from 'jquery';
window.jQuery = $;

export default function showAlertBox(text, cssClass) {
    $(function () {
        $("#alertBox").addClass(cssClass)
        $("#alertBox").text(text)
        $("#alertBox").fadeIn(1000);
    })
    setTimeout(() => {
        $("#alertBox").fadeOut(1000);
    }, 2500);
}