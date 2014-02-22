var main = {

    closeButton: document.getElementById("closePanelButton"),
    SuccessPanel: document.getElementById("SuccessPanel"),
    queryString: location.search,
    thumbnails: document.getElementsByClassName("thumbnail"),

    init: function ()
    {

        //Stänger ner slutförd-uppladdning-rutan
        if (main.SuccessPanel !== null)
        {
            main.closeButton.addEventListener("click", closePanel, false);

            function closePanel()
            {
                main.SuccessPanel.parentNode.removeChild(main.SuccessPanel);
            }
        }

        //Markerar vald bild
        //Ta bort allt utom bildnamnet
        var imgName = main.queryString.split("?Name=")[1];


        for(var i = 0; i<main.thumbnails.length; i++)
        {
            if (main.thumbnails[i].getAttribute("src").indexOf(imgName) > -1)
            {
                main.thumbnails[i].setAttribute("class", "thumbnail selectedImg");
            }
        }



    }
}

window.onload = main.init();