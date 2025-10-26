import { defineConfig } from "vite";
import tailwindcss from "@tailwindcss/vite";

export default defineConfig({
  base: "./",
  root: "Assets",
  plugins: [tailwindcss()],
  build: {
    emptyOutDir: true,
    manifest: true,
    outDir: "../wwwroot/dist",
    rollupOptions: {
      input: {
        app: "./Assets/app.js",
      },
      output: {
        entryFileNames: "[name].js",
        chunkFileNames: "[name].js",
        assetFileNames: "[name].[ext]",
      },
    },
  },
  server: {
    // port: 3000,
    strictPort: true,
  },
});
