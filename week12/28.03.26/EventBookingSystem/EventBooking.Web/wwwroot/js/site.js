const API_BASE = "http://localhost:5258";

let allEvents = [];

async function loadEvents() {
    try {
        const res = await fetch(`${API_BASE}/api/events`);
        const events = await res.json();
        allEvents = events;
        renderEvents(events);
    } catch (err) {
        document.getElementById("loadingSpinner").innerHTML =
            `<p class="text-danger">Failed to load events. Make sure API is running.</p>`;
    }
}

function renderEvents(events) {
    const container = document.getElementById("eventsContainer");
    const spinner = document.getElementById("loadingSpinner");
    const noEvents = document.getElementById("noEvents");

    if (!container) return;

    spinner.style.display = "none";

    if (events.length === 0) {
        noEvents.style.display = "block";
        container.innerHTML = "";
        return;
    }

    noEvents.style.display = "none";

    container.innerHTML = events.map(ev => {
        const date = new Date(ev.date).toLocaleDateString("en-IN", {
            day: "numeric", month: "short", year: "numeric"
        });

        let seatsBadge = `<span class="seats-badge">${ev.availableSeats} seats left</span>`;
        if (ev.availableSeats === 0) {
            seatsBadge = `<span class="seats-badge full">Sold Out</span>`;
        } else if (ev.availableSeats <= 10) {
            seatsBadge = `<span class="seats-badge low">${ev.availableSeats} seats left</span>`;
        }

        const bookBtn = ev.availableSeats === 0
            ? `<button class="btn-book mt-2" disabled style="opacity:0.5;cursor:not-allowed">Sold Out</button>`
            : `<button class="btn-book mt-2" onclick="goToBook(${ev.id})">Book Now</button>`;

        const img = ev.imageUrl
            ? `<img src="${ev.imageUrl}" class="card-img-top" alt="${ev.title}" />`
            : `<div style="height:180px;background:linear-gradient(135deg,#a5d6a7,#f48fb1);border-radius:14px 14px 0 0;display:flex;align-items:center;justify-content:center;font-size:3rem;">🎟️</div>`;

        return `
        <div class="col-md-4 col-sm-6">
            <div class="card event-card">
                ${img}
                <div class="card-body d-flex flex-column">
                    <span class="badge-category mb-2">${ev.category || "General"}</span>
                    <h5 class="fw-bold">${ev.title}</h5>
                    <p class="text-muted small mb-1"><i class="bi bi-geo-alt-fill"></i> ${ev.location}</p>
                    <p class="text-muted small mb-1"><i class="bi bi-calendar-event"></i> ${date}</p>
                    <p class="fw-semibold mb-2" style="color:#e91e63">₹${ev.ticketPrice}</p>
                    ${seatsBadge}
                    ${bookBtn}
                </div>
            </div>
        </div>`;
    }).join("");
}

function filterEvents() {
    const search = document.getElementById("searchInput")?.value.toLowerCase() || "";
    const category = document.getElementById("categoryFilter")?.value || "";

    const filtered = allEvents.filter(ev => {
        const matchSearch = ev.title.toLowerCase().includes(search) ||
            ev.location.toLowerCase().includes(search);
        const matchCategory = category === "" || ev.category === category;
        return matchSearch && matchCategory;
    });

    renderEvents(filtered);
}

function goToBook(eventId) {
    const token = localStorage.getItem("jwt_token");
    if (!token) {
        window.location.href = "/Login";
        return;
    }
    window.location.href = `/BookEvent/${eventId}`;
}

async function loginUser() {
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();
    const errorMsg = document.getElementById("errorMsg");
    const successMsg = document.getElementById("successMsg");

    errorMsg.classList.add("d-none");
    successMsg.classList.add("d-none");

    if (!email || !password) {
        errorMsg.textContent = "Please fill in all fields.";
        errorMsg.classList.remove("d-none");
        return;
    }

    const payload = { email, password };
    console.log("Login payload:", JSON.stringify(payload));

    try {
        const res = await fetch(`${API_BASE}/api/auth/login`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(payload)
        });

        console.log("Login status:", res.status);

        const rawText = await res.text();
        console.log("Login response:", rawText);

        if (!res.ok) {
            errorMsg.textContent = rawText || "Login failed.";
            errorMsg.classList.remove("d-none");
            return;
        }

        const data = JSON.parse(rawText);

        localStorage.setItem("jwt_token", data.token);
        localStorage.setItem("user_name", data.name);
        localStorage.setItem("user_email", data.email);

        successMsg.textContent = "Login successful! Redirecting...";
        successMsg.classList.remove("d-none");

        setTimeout(() => window.location.href = "/", 1000);

    } catch (err) {
        console.log("Login catch error:", err.message);
        errorMsg.textContent = "Cannot connect to server.";
        errorMsg.classList.remove("d-none");
    }
}

async function registerUser() {
    const name = document.getElementById("name").value.trim();
    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();
    const confirmPassword = document.getElementById("confirmPassword").value.trim();
    const errorMsg = document.getElementById("errorMsg");
    const successMsg = document.getElementById("successMsg");

    errorMsg.classList.add("d-none");
    successMsg.classList.add("d-none");

    if (!name || !email || !password || !confirmPassword) {
        errorMsg.textContent = "Please fill in all fields.";
        errorMsg.classList.remove("d-none");
        return;
    }

    if (password.length < 6) {
        errorMsg.textContent = "Password must be at least 6 characters.";
        errorMsg.classList.remove("d-none");
        return;
    }

    if (password !== confirmPassword) {
        errorMsg.textContent = "Passwords do not match.";
        errorMsg.classList.remove("d-none");
        return;
    }

    const payload = { name, email, password };
    console.log("Sending payload:", JSON.stringify(payload));

    try {
        const res = await fetch(`${API_BASE}/api/auth/register`, {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(payload)
        });

        console.log("Response status:", res.status);

        const rawText = await res.text();
        console.log("Raw response:", rawText);

        if (!res.ok) {
            errorMsg.textContent = rawText || "Registration failed.";
            errorMsg.classList.remove("d-none");
            return;
        }

        successMsg.textContent = "Registered successfully! Redirecting to login...";
        successMsg.classList.remove("d-none");

        setTimeout(() => window.location.href = "/Login", 1500);

    } catch (err) {
        console.log("Catch error:", err.message);
        errorMsg.textContent = "Cannot connect to server.";
        errorMsg.classList.remove("d-none");
    }
}

let currentEvent = null;

async function loadEventForBooking() {
    const id = window.location.pathname.split("/").pop();
    const errorMsg = document.getElementById("errorMsg");

    try {
        const res = await fetch(`${API_BASE}/api/events/${id}`);

        if (!res.ok) {
            document.getElementById("loadingEvent").innerHTML =
                `<p class="text-danger">Event not found.</p>`;
            return;
        }

        currentEvent = await res.json();

        document.getElementById("eventTitle").textContent = currentEvent.title;
        document.getElementById("eventLocation").textContent = currentEvent.location;
        document.getElementById("eventDate").textContent = new Date(currentEvent.date)
            .toLocaleDateString("en-IN", { day: "numeric", month: "long", year: "numeric" });
        document.getElementById("eventPrice").textContent = `₹${currentEvent.ticketPrice}`;
        document.getElementById("eventSeats").textContent = currentEvent.availableSeats;

        document.getElementById("seatsInput").max = Math.min(10, currentEvent.availableSeats);

        updateTotal();

        document.getElementById("loadingEvent").style.display = "none";
        document.getElementById("eventDetails").style.display = "block";

    } catch (err) {
        document.getElementById("loadingEvent").innerHTML =
            `<p class="text-danger">Failed to load event.</p>`;
    }
}

function updateTotal() {
    if (!currentEvent) return;
    const seats = parseInt(document.getElementById("seatsInput").value) || 1;
    const total = seats * currentEvent.ticketPrice;
    document.getElementById("totalAmount").textContent = `₹${total}`;
}

async function confirmBooking() {
    const token = localStorage.getItem("jwt_token");
    const errorMsg = document.getElementById("errorMsg");
    const successMsg = document.getElementById("successMsg");

    errorMsg.classList.add("d-none");
    successMsg.classList.add("d-none");

    if (!token) {
        window.location.href = "/Login";
        return;
    }

    const seats = parseInt(document.getElementById("seatsInput").value);

    if (!seats || seats < 1) {
        errorMsg.textContent = "Please enter at least 1 seat.";
        errorMsg.classList.remove("d-none");
        return;
    }

    if (seats > 10) {
        errorMsg.textContent = "Maximum 10 seats allowed per booking.";
        errorMsg.classList.remove("d-none");
        return;
    }

    if (seats > currentEvent.availableSeats) {
        errorMsg.textContent = `Only ${currentEvent.availableSeats} seats available.`;
        errorMsg.classList.remove("d-none");
        return;
    }

    const id = window.location.pathname.split("/").pop();

    try {
        const res = await fetch(`${API_BASE}/api/bookings`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify({ eventId: parseInt(id), seatsBooked: seats })
        });

        const data = await res.json();

        if (!res.ok) {
            errorMsg.textContent = data || "Booking failed.";
            errorMsg.classList.remove("d-none");
            return;
        }

        successMsg.textContent = `🎉 Booking confirmed! ${seats} seat(s) booked. Total: ₹${data.totalAmount}`;
        successMsg.classList.remove("d-none");

        setTimeout(() => window.location.href = "/MyBookings", 2000);

    } catch (err) {
        errorMsg.textContent = "Cannot connect to server.";
        errorMsg.classList.remove("d-none");
    }
}

async function loadMyBookings() {
    const token = localStorage.getItem("jwt_token");

    if (!token) {
        window.location.href = "/Login";
        return;
    }

    try {
        const res = await fetch(`${API_BASE}/api/bookings`, {
            headers: { "Authorization": `Bearer ${token}` }
        });

        const bookings = await res.json();

        document.getElementById("loadingSpinner").style.display = "none";

        if (bookings.length === 0) {
            document.getElementById("noBookings").style.display = "block";
            return;
        }

        document.getElementById("bookingsContainer").style.display = "block";

        const tbody = document.getElementById("bookingsTableBody");

        tbody.innerHTML = bookings.map(b => {
            const date = new Date(b.eventDate).toLocaleDateString("en-IN", {
                day: "numeric", month: "short", year: "numeric"
            });

            const statusClass = b.status === "Confirmed" ? "status-confirmed" : "status-cancelled";

            const cancelBtn = b.status === "Confirmed"
                ? `<button class="btn btn-sm btn-outline-danger" onclick="cancelBooking(${b.id})">Cancel</button>`
                : `<span class="text-muted">-</span>`;

            return `
            <tr>
                <td class="fw-semibold">${b.eventTitle}</td>
                <td>${b.eventLocation}</td>
                <td>${date}</td>
                <td>${b.seatsBooked}</td>
                <td>₹${b.totalAmount}</td>
                <td><span class="${statusClass}">${b.status}</span></td>
                <td>${cancelBtn}</td>
            </tr>`;
        }).join("");

    } catch (err) {
        document.getElementById("loadingSpinner").innerHTML =
            `<p class="text-danger">Failed to load bookings.</p>`;
    }
}

async function cancelBooking(bookingId) {
    const token = localStorage.getItem("jwt_token");

    if (!confirm("Are you sure you want to cancel this booking?")) return;

    try {
        const res = await fetch(`${API_BASE}/api/bookings/${bookingId}`, {
            method: "DELETE",
            headers: { "Authorization": `Bearer ${token}` }
        });

        if (res.ok) {
            alert("Booking cancelled successfully.");
            loadMyBookings();
        } else {
            alert("Failed to cancel booking.");
        }

    } catch (err) {
        alert("Cannot connect to server.");
    }
}

if (document.getElementById("eventsContainer")) loadEvents();
if (document.getElementById("eventDetails") !== null &&
    window.location.pathname.startsWith("/BookEvent")) loadEventForBooking();
if (document.getElementById("bookingsTableBody")) loadMyBookings();