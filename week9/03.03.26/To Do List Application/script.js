const taskInput = document.getElementById("taskInput");
const addTaskBtn = document.getElementById("addTaskBtn");
const taskList = document.getElementById("taskList");

// Load tasks from localStorage
document.addEventListener("DOMContentLoaded", loadTasks);

addTaskBtn.addEventListener("click", addTask);

function addTask() {
    const taskText = taskInput.value.trim();

    if (taskText === "") {
        alert("Please enter a task!");
        return;
    }

    const task = {
        text: taskText,
        completed: false
    };

    saveTask(task);
    renderTask(task);

    taskInput.value = "";
}

function renderTask(task) {
    const li = document.createElement("li");

    const leftDiv = document.createElement("div");
    leftDiv.classList.add("task-left");

    const checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    checkbox.checked = task.completed;

    const span = document.createElement("span");
    span.textContent = task.text;

    if (task.completed) {
        li.classList.add("completed");
    }

    checkbox.addEventListener("change", function () {
        li.classList.toggle("completed");
        updateTaskStatus(task.text, checkbox.checked);
    });

    leftDiv.appendChild(checkbox);
    leftDiv.appendChild(span);

    const deleteBtn = document.createElement("button");
    deleteBtn.textContent = "Delete";
    deleteBtn.classList.add("delete-btn");

    deleteBtn.addEventListener("click", function () {
        li.remove();
        deleteTask(task.text);
    });

    li.appendChild(leftDiv);
    li.appendChild(deleteBtn);

    taskList.appendChild(li);
}

function saveTask(task) {
    const tasks = getTasks();
    tasks.push(task);
    localStorage.setItem("tasks", JSON.stringify(tasks));
}

function getTasks() {
    const tasks = localStorage.getItem("tasks");
    return tasks ? JSON.parse(tasks) : [];
}

function loadTasks() {
    const tasks = getTasks();
    tasks.forEach(task => renderTask(task));
}

function updateTaskStatus(text, completed) {
    const tasks = getTasks();
    const updatedTasks = tasks.map(task =>
        task.text === text ? { ...task, completed } : task
    );
    localStorage.setItem("tasks", JSON.stringify(updatedTasks));
}

function deleteTask(text) {
    const tasks = getTasks();
    const filteredTasks = tasks.filter(task => task.text !== text);
    localStorage.setItem("tasks", JSON.stringify(filteredTasks));
}