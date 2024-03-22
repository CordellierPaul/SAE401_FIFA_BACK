/** @type {import('tailwindcss').Config} */
module.exports = {
  purge: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  darkMode: false, // or 'media' or 'class'
  theme: {
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [require("daisyui")],
  daisyui: {
    themes: [
      {
        mytheme: {
          
          "primary": "#000000",
                   
          "secondary": "#262626",
                   
          "accent": "#0075ff",
                   
          "neutral": "#ff00ff",
                   
          "base-100": "#ffffff",
                   
          "info": "#1d33c4",
                   
          "success": "#84cc16",
                   
          "warning": "#facc15",
                   
          "error": "#ef4444",
                   },
      },
      
    ],
  },
}