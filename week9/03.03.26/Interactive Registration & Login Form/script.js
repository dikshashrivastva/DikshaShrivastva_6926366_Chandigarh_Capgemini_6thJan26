// Email validation
function validateEmail(email) {
    const pattern = /^[^ ]+@[^ ]+\.[a-z]{2,3}$/;
    return pattern.test(email);
}

// ===== REGISTER =====
const registerForm = document.getElementById("registerForm");

if (registerForm) {
    registerForm.addEventListener("submit", function (e) {
        e.preventDefault();

        const username = document.getElementById("regUsername").value.trim();
        const email = document.getElementById("regEmail").value.trim();
        const password = document.getElementById("regPassword").value;
        const confirmPassword = document.getElementById("regConfirmPassword").value;

        if (!validateEmail(email)) {
            alert("Invalid email format!");
            return;
        }

        if (password.length < 6) {
            alert("Password must be at least 6 characters!");
            return;
        }

        if (password !== confirmPassword) {
            alert("Passwords do not match!");
            return;
        }

        const user = { username, email, password };
        localStorage.setItem(email, JSON.stringify(user));

        alert("Registration Successful! Please Login.");
        window.location.href = "login.html";
    });
}

// ===== LOGIN =====
const loginForm = document.getElementById("loginForm");

if (loginForm) {
    loginForm.addEventListener("submit", function (e) {
        e.preventDefault();

        const email = document.getElementById("loginEmail").value.trim();
        const password = document.getElementById("loginPassword").value;

        const storedUser = localStorage.getItem(email);

        if (!storedUser) {
            alert("User not found! Please register.");
            return;
        }

        const user = JSON.parse(storedUser);

        if (user.password === password) {
            alert("Login Successful! Welcome " + user.username);
        } else {
            alert("Incorrect password!");
        }
    });
}