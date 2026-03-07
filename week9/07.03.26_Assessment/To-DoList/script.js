function addTask(){

let input = document.getElementById("taskInput");
let text = input.value.trim();

if(text === ""){
alert("Please enter a task!");
return;
}

let note = document.createElement("div");
note.className = "note";
note.innerText = text;

note.onclick = function(){
note.classList.toggle("done");
}

document.getElementById("taskBoard").appendChild(note);

input.value="";
}

function clearTasks(){
document.getElementById("taskBoard").innerHTML="";
}