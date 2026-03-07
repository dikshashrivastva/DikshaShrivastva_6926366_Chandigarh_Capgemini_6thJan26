function showMessage()
{
    var message = document.getElementById("surprise");

    if(message.style.display === "block")
    {
        message.style.display = "none";
    }
    else
    {
        message.style.display = "block";
    }
}