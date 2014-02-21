var closeButton = document.getElementById("closePanelButton");
var SuccessPanel = document.getElementById("SuccessPanel");

closeButton.addEventListener("click", closePanel, false);

function closePanel()
{
    SuccessPanel.parentNode.removeChild(SuccessPanel);
}