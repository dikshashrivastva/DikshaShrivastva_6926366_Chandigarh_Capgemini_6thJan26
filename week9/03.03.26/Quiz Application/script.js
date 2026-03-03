const questions = [
    {
        question: "Which language runs in the browser?",
        answers: [
            { text: "Python", correct: false },
            { text: "Java", correct: false },
            { text: "JavaScript", correct: true },
            { text: "C++", correct: false }
        ]
    },
    {
        question: "What does CSS stand for?",
        answers: [
            { text: "Creative Style Sheets", correct: false },
            { text: "Cascading Style Sheets", correct: true },
            { text: "Computer Style Sheets", correct: false },
            { text: "Colorful Style Sheets", correct: false }
        ]
    },
    {
        question: "Which tag is used for JavaScript?",
        answers: [
            { text: "<script>", correct: true },
            { text: "<js>", correct: false },
            { text: "<javascript>", correct: false },
            { text: "<code>", correct: false }
        ]
    }
];

const questionElement = document.getElementById("question");
const answerButtons = document.getElementById("answer-buttons");
const nextButton = document.getElementById("next-btn");
const resultBox = document.getElementById("result-box");
const timerProgress = document.getElementById("timer-progress");

let currentQuestionIndex = 0;
let score = 0;
let timer;
let timeLeft = 10;

function startQuiz() {
    currentQuestionIndex = 0;
    score = 0;
    showQuestion();
}

function showQuestion() {
    resetState();
    startTimer();

    let currentQuestion = questions[currentQuestionIndex];
    questionElement.innerText = currentQuestion.question;

    currentQuestion.answers.forEach(answer => {
        const button = document.createElement("button");
        button.innerText = answer.text;
        button.addEventListener("click", () => selectAnswer(button, answer.correct));
        answerButtons.appendChild(button);
    });
}

function resetState() {
    nextButton.style.display = "none";
    answerButtons.innerHTML = "";
    clearInterval(timer);
    timeLeft = 10;
    timerProgress.style.width = "100%";
}

function selectAnswer(button, correct) {
    clearInterval(timer);

    if (correct) {
        button.classList.add("correct");
        score++;
    } else {
        button.classList.add("wrong");
    }

    Array.from(answerButtons.children).forEach(btn => {
        btn.disabled = true;
    });

    nextButton.style.display = "inline-block";
}

nextButton.addEventListener("click", () => {
    currentQuestionIndex++;
    if (currentQuestionIndex < questions.length) {
        showQuestion();
    } else {
        showScore();
    }
});

function showScore() {
    resetState();
    resultBox.classList.remove("hidden");
    resultBox.innerText = `🎉 Your Score: ${score} / ${questions.length}`;
}

function startTimer() {
    timer = setInterval(() => {
        timeLeft--;
        timerProgress.style.width = (timeLeft * 10) + "%";

        if (timeLeft <= 0) {
            clearInterval(timer);
            nextButton.style.display = "inline-block";
        }
    }, 1000);
}

startQuiz();