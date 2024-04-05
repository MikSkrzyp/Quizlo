// navbar-component.js

// Define the navbar component
Vue.component('navbar', {
    template: `
        <nav class="navbar navbar-dark navbar-expand-lg" style="background-color: #3C89AA;">
            <div class="container">
                <a class="navbar-brand" href="#">
                    <!-- Large logo for desktop -->
                    <img v-if="isDesktop" src="images/quizlo-logo.png" id="quizlo-logo" alt="Quizlo Logo" style="width: 90px; height: auto;">
                    <!-- Small logo for tablet and phone -->
                    <img v-else src="images/quizlo-logo.png" id="quizlo-logo" alt="Quizlo Logo" style="width: 60px; height: auto;">
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <div class="navbar-nav ml-auto">
                        <button class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">Home Page</button>
                        <button class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">About Us</button>
                        <button class="btn btn-light mx-2 custom-btn" style="background-color: #60A1BC; color: white; border: none;">Log in / Register</button>
                        <!-- Dark mode toggle button -->
                        <button type="button" class="btn btn-outline-light" @click="toggleDarkMode">{{ darkModeText }}</button>
                    </div>
                </div>
            </div>
        </nav>
    `,
    data() { //zwracanie obiekt komponentu
        return {
            isDesktop: true, // Initially assuming it's desktop
            darkMode: false
        };
    },
    mounted() {
        // Detect screen size on mount
        this.isDesktop = window.innerWidth >= 992;
        window.addEventListener('resize', () => {
            this.isDesktop = window.innerWidth >= 992;
        });

        // Check if dark mode is enabled from local storage
        this.darkMode = localStorage.getItem('darkMode') === 'true';
        this.setDarkMode();
    },
    methods: {
        toggleDarkMode() { // Metoda przełącza tryb ciemny na przeciwny i wywołuje metodę setDarkMode()
            this.darkMode = !this.darkMode;
            this.setDarkMode();
        },
        setDarkMode() {
            if (this.darkMode) {
                document.body.classList.add('dark-mode');
                localStorage.setItem('darkMode', 'true');
            } else {
                document.body.classList.remove('dark-mode');
                localStorage.setItem('darkMode', 'false');
            }
        }
    },
    computed: {
        darkModeText() {
            return this.darkMode ? 'Light Mode' : 'Dark Mode';
        }
    }
});

// Add CSS styles
var style = document.createElement('style');
style.textContent = `
.custom-btn {
    transition: transform 0.3s ease;
}
.custom-btn:hover {
    transform: scale(1.1);
}

/* Style for dark mode */
body.dark-mode {
    background-color: #333;
    color: #fff;
}
`;
document.head.appendChild(style);
