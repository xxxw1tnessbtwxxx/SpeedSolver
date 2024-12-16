import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import mkcert from "vite-plugin-mkcert"
import path from "path"

export default defineConfig({
  server: {
    port: 3001,
  },
  resolve: {
    alias: [{ find: '@', replacement: path.resolve(__dirname, 'src') }],
  },
  plugins: [react()],
  // if needs https
  // plugins: [react(), mkcert()],
})
