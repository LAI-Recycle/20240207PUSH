$(document).ready(function () {
    alert("A");
    // ��ť�a�� .practice-link ���O�������I���ƥ�
    $(".practice-link").on("click", function () {
        // �b�o�̩�J�A�Q�n���檺�{���X
        alert("ActionLink �Q�I���F�I");
    });
});

$(function () {
    alert("B");
    // �Ҧp�A�A�i�H�K�[�I���ƥ�B�z�{�Ǩ�A�� ActionLink
    $(".practice-link").click(function () {
        alert("ActionLink is clicked!");
        // �o�̥i�H�����L���ާ@
    });
});
