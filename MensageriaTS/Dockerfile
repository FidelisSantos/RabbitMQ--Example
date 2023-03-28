FROM node:alpine

WORKDIR /usr/app_ts

COPY package*.json ./

RUN npm install

COPY . .

EXPOSE 4000

CMD ["npm", "run" , "dev"]