$(document).ready(function () {
    alert("A");
    // 監聽帶有 .practice-link 類別的元素點擊事件
    $(".practice-link").on("click", function () {
        // 在這裡放入你想要執行的程式碼
        alert("ActionLink 被點擊了！");
    });
});

$(function () {
    alert("B");
    // 例如，你可以添加點擊事件處理程序到你的 ActionLink
    $(".practice-link").click(function () {
        alert("ActionLink is clicked!");
        // 這裡可以執行其他的操作
    });
});
