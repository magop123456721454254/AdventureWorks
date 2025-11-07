// Only for client components
import { ApolloClient, InMemoryCache, HttpLink } from '@apollo/client';

export const client = new ApolloClient({
  link: new HttpLink({
    uri: process.env.NEXT_PUBLIC_API_URL || 'http://localhost:5000/graphql',
  }),
  cache: new InMemoryCache(),
});
