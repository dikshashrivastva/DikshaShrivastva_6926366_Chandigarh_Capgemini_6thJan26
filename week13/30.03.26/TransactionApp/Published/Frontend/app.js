const API_URL = "http://localhost:5003/api";

// ─── AUTH ───────────────────────────────────────────

async function login() {
  clearErrors();
  const username = document.getElementById("username").value.trim();
  const password = document.getElementById("password").value.trim();

  if (!username) { showError("usernameError", "Username is required"); return; }
  if (!password) { showError("passwordError", "Password is required"); return; }

  try {
    const res = await fetch(`${API_URL}/auth/login`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username, password })
    });

    if (!res.ok) { showError("loginError", "Invalid username or password"); return; }

    const data = await res.json();
    localStorage.setItem("token", data.token);
    localStorage.setItem("username", username);
    window.location.href = "dashboard.html";

  } catch {
    showError("loginError", "Could not connect to server");
  }
}

async function register() {
  clearErrors();
  const username = document.getElementById("username").value.trim();
  const password = document.getElementById("password").value.trim();

  if (!username) { showError("usernameError", "Username is required"); return; }
  if (!password) { showError("passwordError", "Password is required"); return; }

  try {
    const res = await fetch(`${API_URL}/auth/register`, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ username, password })
    });

    if (!res.ok) { showError("loginError", "Username already exists"); return; }

    showError("loginError", "✅ Registered! You can now sign in.");

  } catch {
    showError("loginError", "Could not connect to server");
  }
}

function logout() {
  localStorage.removeItem("token");
  localStorage.removeItem("username");
  window.location.href = "index.html";
}

// ─── TRANSACTIONS ────────────────────────────────────

async function loadTransactions() {
  const token = localStorage.getItem("token");
  if (!token) { window.location.href = "index.html"; return; }

  try {
    const res = await fetch(`${API_URL}/transactions`, {
      headers: { "Authorization": `Bearer ${token}` }
    });

    if (res.status === 401) { window.location.href = "index.html"; return; }

    const transactions = await res.json();
    renderTransactions(transactions);
    renderStats(transactions);

  } catch {
    console.error("Failed to load transactions");
  }
}

function renderTransactions(data) {
  const tbody = document.getElementById("transactionBody");
  tbody.innerHTML = "";

  if (data.length === 0) {
    tbody.innerHTML = `<tr><td colspan="4" style="text-align:center; color:#64748b;">No transactions found</td></tr>`;
    return;
  }

  data.forEach((t, i) => {
    const date = new Date(t.date).toLocaleDateString("en-IN", {
      day: "2-digit", month: "short", year: "numeric"
    });

    const row = `
      <tr>
        <td style="color:#64748b">${i + 1}</td>
        <td>${date}</td>
        <td><span class="badge ${t.type.toLowerCase()}">${t.type}</span></td>
        <td style="font-weight:600; color:${t.type === 'Credit' ? '#34d399' : '#f87171'}">
          ${t.type === 'Credit' ? '+' : '-'} ₹${t.amount.toLocaleString("en-IN")}
        </td>
      </tr>`;
    tbody.innerHTML += row;
  });
}

function renderStats(data) {
  const credits = data.filter(t => t.type === "Credit").reduce((s, t) => s + t.amount, 0);
  const debits  = data.filter(t => t.type === "Debit").reduce((s, t) => s + t.amount, 0);

  document.getElementById("totalCredit").textContent = `₹${credits.toLocaleString("en-IN")}`;
  document.getElementById("totalDebit").textContent  = `₹${debits.toLocaleString("en-IN")}`;
  document.getElementById("totalCount").textContent  = data.length;
}

// ─── HELPERS ─────────────────────────────────────────

function showError(id, msg) {
  const el = document.getElementById(id);
  if (el) el.textContent = msg;
}

function clearErrors() {
  ["usernameError", "passwordError", "loginError"].forEach(id => {
    const el = document.getElementById(id);
    if (el) el.textContent = "";
  });
}

// ─── INIT ─────────────────────────────────────────────

if (window.location.pathname.includes("dashboard")) {
  loadTransactions();
}