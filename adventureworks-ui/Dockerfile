# Build stage
FROM node:20-alpine AS builder
WORKDIR /app

COPY adventureworks-ui/package*.json ./
RUN npm ci

COPY adventureworks-ui/. ./
RUN npm run build

# Production stage
FROM node:20-alpine AS runtime
WORKDIR /app
COPY --from=builder /app/.next ./.next
COPY --from=builder /app/public ./public
COPY --from=builder /app/package*.json ./

# Install only production deps
RUN npm ci --omit=dev

EXPOSE 3000
CMD ["npm", "start"]
