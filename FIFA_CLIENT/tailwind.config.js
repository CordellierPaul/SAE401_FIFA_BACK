/** @type {import('tailwindcss').Config} */
module.exports = {
  purge: ['./index.html', './src/**/*.{vue,js,ts,jsx,tsx}'],
  darkMode: false, // or 'media' or 'class'
  content: [
    "./node_modules/flowbite/**/*.js"
  ],
  theme: {
    extend: {},
  },
  variants: {
    extend: {},
  },
  plugins: [
    require('daisyui'),
    require('flowbite/plugin')
  ],
  daisyui: {
    themes: [
      {
        mytheme: {
          
          "primary": "#000000",
                   
          "secondary": "#262626",
                   
          "accent": "#0075ff",
                   
          "neutral": "#a8a29e",
                   
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