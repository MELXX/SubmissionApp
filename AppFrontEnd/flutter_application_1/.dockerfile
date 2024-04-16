# Use the official Flutter image as the base image
FROM cirrusci/flutter:stable AS builder

# Set the working directory in the container
WORKDIR /app

# Copy the pubspec.yaml file to the working directory
COPY pubspec.yaml .

# Copy the entire project to the working directory
COPY . .

# Run flutter pub get to install dependencies
RUN flutter pub get

# Build the Flutter web app
RUN flutter build web --release

# Use Nginx to serve the Flutter web app
FROM nginx:alpine

# Copy the built Flutter web app from the builder stage to the Nginx web root directory
COPY --from=builder /app/build/web /usr/share/nginx/html

# Expose port 80 to the outside world
EXPOSE 80

# Command to run the Nginx server
CMD ["nginx", "-g", "daemon off;"]
